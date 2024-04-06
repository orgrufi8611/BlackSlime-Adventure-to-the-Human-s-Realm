using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public SoundPlayShot sound;
    public float speed;
    public float damage;
    public bool isEnemy;
    bool initDirection,move;
    Rigidbody2D rb;
    Animator animator;
    GameObject slime;
    GameLogic gameLogic;

    // Start is called before the first frame update
    void Start()
    {
        move = true;
        initDirection = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        slime = GameObject.Find("Slime");
        damage = slime.GetComponent<SlimeController>().slimeState.damage;
        rb.gravityScale = 0;
        sound.audioS.volume = 0.1f;
        sound.PlaySpawnSound();
    }
    private void Update()
    {
        //set to the correct direction
        if (!isEnemy && !initDirection)
        {
            initDirection=true;
            speed = speed * slime.GetComponent<SlimeController>().slimeDirection;
        }
        
        if(move && gameLogic.active)
        {
            animator.speed = 1;
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (!gameLogic.active)
        {
            animator.speed = 0;
        }

        if(Mathf.Abs(transform.position.x - slime.transform.position.x) > ScreenSize.screenUnitWidth * 1.5)
        {
            DestroyShot();
        }
    }

    //destroy the gameobject upon explotion
    public void DestroyShot()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if(isEnemy && hitInfo.gameObject.tag == "Slime")
        {
            move = false;
            hitInfo.gameObject.GetComponent<SlimeController>().Hit(damage);
            animator.SetTrigger("Hit");
            sound.PlayHitSound();
        }
        else if(!isEnemy )
        {
            if ( hitInfo.gameObject.tag == "Enemy")
            {
                move = false;
                animator.SetTrigger("Hit");
                sound.PlayHitSound();
                hitInfo.gameObject.GetComponent<EnemyMovement>().Hit(damage);
            }
            else if( hitInfo.gameObject.tag == "Boss")
            {
                move = false;
                animator.SetTrigger("Hit");
                sound.PlayHitSound();
                hitInfo.gameObject.GetComponent<BossBehavior>().Hit(damage);
            }
            if( hitInfo.gameObject.tag == "Ground")
            {
                move = false;
                sound.PlayHitSound();
                animator.SetTrigger("Hit");
            }
        }
    }

    
    // Update is called once per frame

}
