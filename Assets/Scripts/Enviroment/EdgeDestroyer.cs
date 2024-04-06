using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" ||  collision.gameObject.tag == "Shot")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Slime")
        {
            GameObject.Find("GameLogic").GetComponent<GameLogic>().GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            Destroy(collision.gameObject);
        }
    }
}
