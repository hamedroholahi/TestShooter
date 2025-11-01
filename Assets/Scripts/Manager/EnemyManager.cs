using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, Imanager
{

    private List<BaseEnemy> enemies = new();

    public List<BaseEnemy> Enemies => enemies;

    

    public void Init()
    {

    }

    public void AddEnemy(BaseEnemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(BaseEnemy enemy)
    {
        enemies.Remove(enemy);
        
        if (enemies.Count > 0) 
            return;
        
        GameManager.Instance.WaveManager.CheckEndEnemy();
    }
    
}
