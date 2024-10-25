using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object Pooling to reuse instances of frequently spawned objects, optimizing memory and performance.
/// </summary>
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; // Prefab for the objects to be pooled
    private Queue<GameObject> pool = new Queue<GameObject>();

    /// <summary>
    /// Retrieves an object from the pool, or creates a new one if pool is empty.
    /// </summary>
    public GameObject Get()
    {
        if (pool.Count == 0)
            AddObjects(1); // Add new object if pool is empty

        return pool.Dequeue(); // Retrieve object from pool
    }

    /// <summary>
    /// Returns an object to the pool for reuse.
    /// </summary>
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false); // Disable object
        pool.Enqueue(obj);    // Enqueue back to pool
    }

    /// <summary>
    /// Adds objects to the pool, useful for initializing the pool.
    /// </summary>
    private void AddObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newObj = Instantiate(prefab); // Instantiate new object
            newObj.SetActive(false); // Set inactive
            pool.Enqueue(newObj); // Add to pool
        }
    }
}
