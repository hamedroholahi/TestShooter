using UnityEngine;


public class PoolableObject : MonoBehaviour
{
    [HideInInspector] public ObjectPool pool;

    public void BackToPool()
    {
        if (pool != null && gameObject.activeInHierarchy)
        {
            pool.BackToPool(gameObject);
        }
    }
}