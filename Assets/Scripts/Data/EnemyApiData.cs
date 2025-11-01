using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyApiData
{
    public EnemyType type;
    public int count;
}

[System.Serializable]
public class Wave
{
    public List<EnemyApiData> enemy;
}

[System.Serializable]
public class WaveList
{
    public List<Wave> waves;
}




public enum EnemyType : byte
{
    None = 0,
    GreenEnemy = 1,
    YellowEnemy = 2,
    RedEnemy = 3
}
