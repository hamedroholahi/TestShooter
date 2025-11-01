using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4Bullet : BaseBullet
{
    

    public override void Explosion()
    {
        enemyTarget.TakeDamage(damage);
        BackToPool();
    }
}
