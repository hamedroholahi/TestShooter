using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private EnemyManager enemyManager;
    
    [SerializeField] private Transform poolParent;
    [SerializeField] private PlayerController player;

    


    public WaveManager WaveManager => waveManager;
    public SpawnManager SpawnManager => spawnManager;
    public EnemyManager EnemyManager => enemyManager;

    public int currentWave => waveManager.CurrentWave;

    public PlayerController Player => player;
    
    
    private Observer<float> health = new();
    
    private List<ObjectPool> pools = new();

    public float Health => health.Value;

    
    void Start()
    {
        health.Value = 100;
        Boot();
    }

    private void Boot()
    {
        InitiatePools();
        spawnManager.Init(pools);
        player.Init();
        waveManager.Init();
    }
    
    private void InitiatePools()
    {
        for (int i = 0; i < poolParent.childCount; i++)
        {
            var child = poolParent.GetChild(i);
            if (child.TryGetComponent(out ObjectPool pool))
            {
                pools.Add(pool);
            }
        }


        for (int i = 0; i < pools.Count; i++)
            pools[i].Init();
    }
    
    public void SetDamage(float damageAmount)
    {
        health.Value -= damageAmount;

        if (health.Value > 0) return;

        Debug.LogError("GameOver");
    }

    public void SubscribeHealth(Action action)
    {
        health.OnChange += action;
    }
}
