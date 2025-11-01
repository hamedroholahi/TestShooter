using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public const string GREEM_ENEMY = "Green-Enemy-Pool";
    public const string YELLOW_ENEMY = "Yellow-Enemy-Pool";
    public const string RED_ENEMY = "Red-Enemy-Pool";
    
    public const string AMMO_BOX = "Ammo-Box-Pool";
    
    public const string UZI_BULLET = "Uzi-Bullet-Pool";
    public const string GRENADE_BULLET = "Grenaded-Bullet-Pool";
    public const string M4_BULLET = "M4-Bullet-Pool";


    public static string EnemyTypeToName(EnemyType enemyType)
    {
        return enemyType switch
        {
            EnemyType.GreenEnemy => GREEM_ENEMY,
            EnemyType.YellowEnemy => YELLOW_ENEMY,
            EnemyType.RedEnemy => RED_ENEMY,
            _ => ""
        };
    }

    public static string WeaponTypeBulletToName(WeaponType weaponType)
    {
        return weaponType switch
        {
            WeaponType.Uzi => UZI_BULLET,
            WeaponType.M4 => M4_BULLET,
            WeaponType.Grenade => GRENADE_BULLET,
            _ => ""
        };
    }

    public static string GetBoxName()
    {
        return AMMO_BOX;
    }
}
