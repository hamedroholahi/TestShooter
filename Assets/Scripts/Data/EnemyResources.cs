using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Enemy Resources" , menuName = "ScriptableObjects/Enemy/Enemy Resources")]
public class EnemyResources : ScriptableObject
{
    public List<EnemyData> enemies;
}
