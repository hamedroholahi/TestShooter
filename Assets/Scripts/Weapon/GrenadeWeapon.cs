using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeWeapon : BaseWeapon
{
     public override void Fire()
    {
        if (!CanFire())
            return;
        GrenadeBullet grenadeBullet = GameManager.Instance.SpawnManager.SpawnBullet(weaponType) as GrenadeBullet;
        grenadeBullet.Spawn(firePoint.position, damage);

        bulletNum.Value--;
    }

     public override bool IsFireCooldown()
    {
        return true;
    }
}