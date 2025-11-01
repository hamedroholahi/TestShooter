using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4Weapon : BaseWeapon
{
    public override void Fire()
    {
        if(!CanFire())
            return;
        M4Bullet m4Bullet = GameManager.Instance.SpawnManager.SpawnBullet(weaponType) as M4Bullet;
        m4Bullet.Spawn(firePoint.position , damage);
        
        bulletNum.Value--;
        cooldownPercent.Value += cooldown;
    }

    public override bool IsFireCooldown()
    {
        return cooldownPercent.Value < 100;
    }
}
