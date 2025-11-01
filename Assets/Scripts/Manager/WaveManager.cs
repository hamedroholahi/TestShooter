using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WaveManager : MonoBehaviour , Imanager
{
    private string waveDataUrl = "http://www.profc.ir/users/shooterWaves";
    
    public List<Wave> waves = new List<Wave>();
    private Observer<int> currentWaveIndex = new();
    public int CurrentWave => currentWaveIndex.Value;

    public int TotalWave => waves.Count;
    
    
    private int totalEnemySpawn = 0;
    private int numberEnemySpawn = 0;

    public void Init()
    {
        StartCoroutine(LoadWavesFromServer());
        
    }
    
    
    public void SubscribeWaveIndex(Action action)
    {
        currentWaveIndex.OnChange += action;
    }

    public void UnsubscribeWaveIndex(Action action)
    {
        currentWaveIndex.OnChange -= action;
    }

    public IEnumerator StartNextWave()
    {
        Debug.Log($"Starting Wave {CurrentWave +1}");

        totalEnemySpawn = 0;
        numberEnemySpawn = 0;

        foreach (var enemyData in waves[CurrentWave].enemy)
        {
            totalEnemySpawn += enemyData.count;
            
            for (int i = 0; i < enemyData.count; i++)
            {
                GameManager.Instance.SpawnManager.SpawnEnemy(enemyData.type);
                numberEnemySpawn++;
                yield return new WaitForSeconds(2);
            }
        }

        GameManager.Instance.SpawnManager.SpawnAmmoBox();
    }

    IEnumerator LoadWavesFromServer()
    {
        UnityWebRequest request = UnityWebRequest.Get(waveDataUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            ParseWaveData(json);
        }
        else
        {
            Debug.LogError("Failed to load waves: " + request.error);
        }
    }
    
    
    void ParseWaveData(string json)
    {
        APIData<WaveList> root = JsonUtility.FromJson<APIData<WaveList>>(json);

        if (root != null && root.ok == 1 && root.data != null)
        {
            waves = root.data.waves;
            currentWaveIndex.Callingtener();
            StartCoroutine(StartNextWave());
            
            Debug.Log($"Loaded {waves.Count} waves from server.");
        }
        else
        {
            Debug.LogError("Invalid JSON format or missing data.");
        }
    }
    
    
    public void CheckEndEnemy()
    {
        if (totalEnemySpawn > numberEnemySpawn)
            return;

        if (CurrentWave >= waves.Count - 1)
        {
            Debug.Log("All Waves Complete");
            return;
        }

        
        currentWaveIndex.Value++;

        StartCoroutine(StartNextWave());
        
    }
}
