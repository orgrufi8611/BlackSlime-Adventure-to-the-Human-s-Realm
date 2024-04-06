using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float hp;
    public bool doubleDmg;
    SlimeController slime;
    GameLogic gameLogic;
    // Start is called before the first frame update
    void Start()
    {
        slime = GameObject.Find("Slime").GetComponent<SlimeController>();
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slime")
        {
            if(doubleDmg)
            {
                slime.DoubleDmg();
            }
            gameLogic.IncreaseHealth(hp);
            Destroy(gameObject);
        }
    }
}
