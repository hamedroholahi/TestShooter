using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "Weapon Data" , menuName = "ScriptableObjects/Weapon/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public WeaponType weaponType;
    public BaseWeapon weaponPrefab;
    public float damage;
    public float fireRate;
    public float coolDown;
    public float coolingRate;
    public int totalBullet;
    public int defaultBulletNum;
}

public enum WeaponType : byte
{
    Uzi = 1,
    M4 = 2,
    Grenade = 3,
}
