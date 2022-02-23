using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Object
{
    public Transform trans;
    [SerializeField]
    protected T prefab;
    [SerializeField]
    protected int least_amount;

    private Queue<T> objects = new Queue<T>();

    protected virtual void Awake()
    {
        trans = transform;
        AddObject(least_amount);
    }

    public virtual T Get()
    {
        if (objects.Count < least_amount)
        {
            AddObject(1);
#if UNITY_EDITOR
            //Debug.Log("Create 1 New " + prefab.name);
#endif
        }
        T obj = objects.Dequeue();
        //obj.enabled = true;
        return obj;
    }

    protected void AddObject(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(prefab, trans);
            objects.Enqueue(obj);
        }
    }

    public virtual void ReturnToPool(T obj)
    {
        objects.Enqueue(obj);
    }
}

