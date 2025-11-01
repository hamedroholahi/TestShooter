using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseEnemy : MonoBehaviour
{
    protected float speed , damage , health;

    private EnemyType enemyType;
    public EnemyType EnemyType => enemyType;

    private Vector3 targetPosition;

    public void Init(EnemyData enemyData)
    {
        damage = enemyData.damage;
        speed = enemyData.speed;
        health = enemyData.maxHealth;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Vector3.Distance(transform.position , targetPosition) < 0.1f)
        {
            GameManager.Instance.SetDamage(damage);
            GetComponent<PoolableObject>().BackToPool();
            GameManager.Instance.EnemyManager.RemoveEnemy(this);
            return;
        }

        Vector3 direction = targetPosition - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime) , Space.World);
    }

    public virtual void Spawn(Vector3 spawnPosition , EnemyData enemyData , Transform targetPoint)
    {
        transform.position = spawnPosition;
        Vector3 pos = targetPoint.position;
        targetPosition = new Vector3(spawnPosition.x, pos.y, spawnPosition.z);
        Init(enemyData);
    }

   

    public void Die()
    {
        GameManager.Instance.EnemyManager.RemoveEnemy(this);
        GetComponent<PoolableObject>().BackToPool();
    }


}
