using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : SingletonBase<GameUI>
{
    [SerializeField] private TMP_Text waveText, healthText , waveTextCenter;
    [SerializeField] private GameObject panelCenterWave;

    private void Start()
    {
        GameManager.Instance.WaveManager.SubscribeWaveIndex(UpdateWaveView);
        GameManager.Instance.SubscribeHealth(UpdateHealthView);
        
        UpdateHealthView();
    }

    void UpdateWaveView()
    {
        int wave = GameManager.Instance.currentWave +1;
        int totalWave = GameManager.Instance.WaveManager.TotalWave;
        waveText.SetText(wave + "/" + totalWave);
        waveTextCenter.SetText("Wave " + wave);
        StartCoroutine(ShowWaveCenter());
    }

    void UpdateHealthView()
    {
        healthText.SetText(GameManager.Instance.Health.ToString());
    }

    IEnumerator ShowWaveCenter()
    {
        panelCenterWave.SetActive(true);
        yield return new WaitForSeconds(2);
        panelCenterWave.SetActive(false);
    }
}
