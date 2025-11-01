using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : BaseBullet
{
   

    public override void Explosion()
    {
        DetectDamageEnemies();
        BackToPool();
    }
    

    private void DetectDamageEnemies()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, areaDamage, enemyLayer);
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<IKillable>().TakeDamage(damage);
        }
    }
}
