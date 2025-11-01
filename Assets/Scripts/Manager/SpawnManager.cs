using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform targetPoint;
    
    
    [SerializeField] private Transform enemyParent , bulletParent;

    
    private List<ObjectPool> pools = new();
    private Dictionary<string, ObjectPool> poolDic = new();

    public void Init(List<ObjectPool> pools)
    {
        this.pools = pools;
        foreach (var pool in pools)
            poolDic.Add(pool.gameObject.name, pool);
    }

    public BaseEnemy SpawnEnemy(EnemyType enemyType)
    {
        var poolName = GameData.EnemyTypeToName(enemyType);
        if (String.IsNullOrEmpty(poolName))
        {
            Debug.LogError("Missing Pool");
            return null;
        }

        var pool = poolDic[poolName];
        float x = Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x);

        Vector3 spawnPosition = new Vector3(x, spawnPoints[0].position.y, spawnPoints[0].position.z);
        
        
        var obj = pool.GetObject<BaseEnemy>();
        obj.transform.SetParent(enemyParent);

        EnemyData data = AppData.Instance.GetEnemyDataByType(enemyType);
        obj.Spawn(spawnPosition, data , targetPoint);
        GameManager.Instance.EnemyManager.AddEnemy(obj);

        
        return obj;
        
    }

    public BaseBullet SpawnBullet(WeaponType weaponType)
    {
        var poolName = GameData.WeaponTypeBulletToName(weaponType);
        
        if (String.IsNullOrEmpty(poolName))
        {
            Debug.LogError("Missing Pool");
            return null;
        }
        var pool = poolDic[poolName];
        var obj = pool.GetObject<BaseBullet>();
        obj.transform.SetParent(bulletParent);

        return obj;
    }
    
    public void SpawnAmmoBox()
    {
        
        var poolName = GameData.GetBoxName();
        if (String.IsNullOrEmpty(poolName))
        {
            Debug.LogError("Missing Pool");
            return;
        }
        
        var pool = poolDic[poolName];
        var obj = pool.GetObject<AmmoBox>();
        
        Camera cam = Camera.main;

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Vector3 camPos = cam.transform.position;
        
        float halfWidth = obj.Sprite.bounds.size.x;

        float leftX = camPos.x - width / 2f;
        leftX += halfWidth;
        float rightX = camPos.x + width / 2f;
        rightX -= halfWidth;

        float minY = camPos.y - height / 2f;
        float maxY = camPos.y + height / 2f;

        bool spawnLeft = Random.value < 0.5f;
        float spawnX = spawnLeft ? leftX : rightX;

        float spawnY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

        
        
        
        obj.transform.SetParent(enemyParent);
        obj.transform.position = spawnPos;
        
    }
}

