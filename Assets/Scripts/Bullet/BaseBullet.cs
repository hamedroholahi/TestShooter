using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField] protected float speed , areaDamage;
    [SerializeField] protected LayerMask enemyLayer;
    protected float damage;

    private bool isActive = false;

    protected IKillable enemyTarget;
    private Camera mainCam;

    public void Init(float damage)
    {
        mainCam = Camera.main;
        this.damage = damage;
        isActive = true;
    }

    private void Update()
    {
        if (!isActive)
            return;

        Vector3 screenPos = mainCam.WorldToViewportPoint(transform.position);
        
        if (screenPos.x < 0 || screenPos.x >1 || screenPos.y<0 || screenPos.y>1)
        {
            BackToPool();
            return;
        }

        Move();

        DetectEnemy();
    }

    public abstract void Explosion();

    public void Move()
    {
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }

    public void DetectEnemy()
    {
        RaycastHit2D enemy = Physics2D.CircleCast(transform.position, 0.05f, transform.up, speed * Time.deltaTime, enemyLayer);

        if (enemy.collider != null)
        {
            isActive = false;
            enemyTarget = enemy.collider.GetComponent<IKillable>();
            Explosion();
        }
    }

    public void Spawn(Vector3 spawnPosition, float damage)
    {
        transform.position = spawnPosition;
        Init(damage);
    }

    public void BackToPool()
    {
        isActive = false;
        GetComponent<PoolableObject>().BackToPool();
    }
}