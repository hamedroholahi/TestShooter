using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "Enemy Data" , menuName = "ScriptableObjects/Enemy/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public EnemyType enemyType;
    public float damage;
    public float maxHealth;
    public float speed;
    public int reward;
}