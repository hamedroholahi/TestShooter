using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject targetObject;
    public int count;
    public bool canGrow;

    [SerializeField] private List<GameObject> objectList = new();

    public void Init()
    {
        objectList.Clear();
        for (int i = 0; i < count; i++)
        {
            CreateGameObject();
        }
    }

    public void SetCount(int count) => this.count = count;


    public T GetObject<T>()
    {
        var firstResult = objectList.Find(t => !t.activeInHierarchy);

        if (firstResult != null)
        {
            firstResult.transform.SetParent(null);
            firstResult.gameObject.SetActive(true);
            return firstResult.GetComponent<T>();
        }

        if (canGrow)
        {
            CreateGameObject();
            return GetObject<T>();
        }

        return default(T);
    }

    public void BackToPool(GameObject obj)
    {
        obj.transform.SetParent(transform);
        obj.transform.position = new Vector3(-1000, -1000, -1000);
        obj.SetActive(false);
    }

    public void CreateGameObject()
    {
        var result = Instantiate(targetObject, transform);
        result.transform.position = new Vector3(-1000, -1000, -1000);
        result.GetComponent<PoolableObject>().pool = this;
        result.SetActive(false);
        objectList.Add(result);
    }
}