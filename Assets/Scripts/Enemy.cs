using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life; 
    public GameObject player; //Essa

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");//Essa
    }


    void Update()
    {
        if(life <= 0)
        {
            player.GetComponent<Player>().enemiesDefeat += 1;//Essa
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Colliders/HitBox")
        {
            life -= 1;
        }
        else if(collision.gameObject.tag == "Colliders/HurtBox") 
        {
            collision.GetComponentInParent<Player>().hp -= 10; 
        }
    }
}
