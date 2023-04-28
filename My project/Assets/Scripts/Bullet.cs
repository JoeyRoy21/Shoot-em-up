using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    Rigidbody2D rb;
    int dir = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void ChangeDirection()
    {
        dir*=-1;
    }

   
    void Update()
    {
        rb.velocity = new Vector2(0,10*dir);   
    }

    void OnTriggerEnter2D(Collider2D col){
        if (dir == 1){
            if (col.gameObject.tag == "Enemy"){
                    col.gameObject.GetComponent<Enemy>().Damage();
                    //Destroy(gameObject);
                    gameObject.SetActive(false);
            }
        }else { 
            if (col.gameObject.tag == "Player"){
                    col.gameObject.GetComponent<Movement>().Damage();
                    //Destroy(gameObject);
                    gameObject.SetActive(false);
            }
        }
    }

    public void OnObjectSpawn()
    {
        throw new System.NotImplementedException();
    }

    public void OnEnable()
    {
        StartCoroutine("Disable");
        

    }

    public IEnumerator Disable()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

}
