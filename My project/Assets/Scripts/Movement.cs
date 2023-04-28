using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Added to object pool 
    public ObjectPooler objectPooler;

    private void Start()
    {
        
    }
    // Added to object pool 

    int delay = 0;
    GameObject a, b; 
    public GameObject bullet;
    Rigidbody2D rb;
    public float speed;
    int health = 3; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
    }

  

   
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed, 0),ForceMode2D.Impulse);
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical") * speed), ForceMode2D.Impulse);

        //continuously shoot
         if (Input.GetKey(KeyCode.Space) && delay > 5)
        {
            Shoot();
            Debug.Log("shoot");
        }
           

        delay++;

    }

    public void Damage()
    {
        health--;
        if (health == 0)
            Destroy(gameObject);
            //gameObject.SetActive(false);
    }

    // Allows the user to spawn new game objects in the scene, form code, as your game runs
    void Shoot()
    {
        delay = 0;
        //Instantiate(bullet, a.transform.position, Quaternion.identity);
        //Instantiate(bullet, b.transform.position, Quaternion.identity);
        objectPooler.SpawnFromPool("royBullet", a.transform.position, Quaternion.identity);
        objectPooler.SpawnFromPool("royBullet", b.transform.position, Quaternion.identity);
    }

}
