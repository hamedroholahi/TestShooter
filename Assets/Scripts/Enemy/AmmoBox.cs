using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour , IKillable
{

    [SerializeField] private SpriteRenderer sprite;
    public SpriteRenderer Sprite => sprite;
    public void TakeDamage(float damageAmount)
    {
        GameManager.Instance.Player.FullAmmoAllWapon();
        Die();
    }
    
    public void Die()
    {
        GetComponent<PoolableObject>().BackToPool();
    }
}
