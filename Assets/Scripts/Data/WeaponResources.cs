using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Weapon Resources" , menuName = "ScriptableObjects/Weapon/Weapon Resources")]
public class WeaponResources : ScriptableObject
{
   public List<WeaponData> weapons;
}
