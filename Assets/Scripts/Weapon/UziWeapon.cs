using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziWeapon : BaseWeapon
{
    public override void Fire()
    {
        if(!CanFire())
            return;
        UziBullet uziBullet = GameManager.Instance.SpawnManager.SpawnBullet(weaponType) as UziBullet;
        uziBullet.Spawn(firePoint.position , damage);
                
        bulletNum.Value--;
    }

    public override bool IsFireCooldown()
    {
        return true;
    }
}
