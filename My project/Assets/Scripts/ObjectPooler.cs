using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;

    }

    

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        // For each pool the player wants to create
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            //  The player makes sure to add all the objects that the player wants to add to the queue
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            // Add the pool to the dictionary 
            poolDictionary.Add(pool.tag, objectPool);

        }

        

    }


    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {

        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't exsit.");
            return null;
        }
        Debug.Log("spawning");
        

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        //Configure object to spawn
        // Taken the object that the player wants to spawn set it to active and moved it to desired position 
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        // Add it back to the queue so the object can be reused 

        poolDictionary[tag].Enqueue(objectToSpawn);


        return objectToSpawn;
    }
    
}
