using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float rate;
    public GameObject[] enemies;
    public int waves = 1;
    public ObjectPooler objectPooler;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }


    void SpawnEnemy()
    {
        //Gets 3 random nums and the if statment makes sure it isn't going to be the same numbers 
        //That way the enemies don't over lap 
        List<int> numbers = new List<int>();
        while(numbers.Count < waves)
        {
            int temp = Random.Range(-9, 8);
            //check to see if the list constants num
            if(!numbers.Contains(temp) )
            {
                numbers.Add(temp);
            }
        }
        //Waves need to match waves of list
        //Pick a random num from whole number then convert to float num
        foreach (int i in numbers)
            //Instantiate(enemies[(int)Random.Range(0, enemies.Length)],new Vector3(Random.Range(-8.5f,8.5f),7,0),Quaternion.identity);
            objectPooler.SpawnFromPool("PurpleEnemy", new Vector3(i + 0.5f, 7, 0), Quaternion.identity);
    }
}