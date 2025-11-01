using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziBullet : BaseBullet
{
    
    public override void Explosion()
    {
        enemyTarget.TakeDamage(damage);
        BackToPool();
    }

}
