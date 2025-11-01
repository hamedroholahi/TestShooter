using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppData : SingletonBase<AppData>
{
    [SerializeField] private EnemyResources enemies;
    [SerializeField] private WeaponResources weapons;
    
    public EnemyData GetEnemyDataByType(EnemyType enemyType) => enemies.enemies.Find(t => t.enemyType == enemyType);
    public List<WeaponData> WeaponDatas => weapons.weapons;


}
