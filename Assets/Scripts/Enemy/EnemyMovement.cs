using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyAttributesSO enemyAtt;
    public HealthBar healthBar;
    public SoundPlayerEnemy sound;

    float sizeX,sizeY;
    bool grounded;
   
    float y, inY;
    int verticalDirection;
    float lives;
    bool alive;

    GameObject slime;
    float slimeDirection;
    
    GameLogic gameLogic;
    
    EnemyManager em;
    
    Rigidbody2D rb;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        //setting enemy components, enemy manager, player transform
        em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        slime = GameObject.Find("Slime");
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        slimeDirection = slime.transform.position.x < transform.position.x ? -1 : 1;
        lives = enemyAtt.lives * gameLogic.lvl;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        healthBar.SetMaxHealth(lives);
        alive = true;
        //getting object size
        sizeX = transform.localScale.x;
        sizeY = transform.localScale.y;
        
        //setting flyer enemy
        if(enemyAtt.isFly) 
        {
            grounded = false;
            rb.gravityScale = 0;
        }
        else
        {
            grounded= true;
            rb.gravityScale = 10;
        }
        inY = transform.position.y;
        verticalDirection = 1;

        sound.audioS.volume = 0.1f;

        sound.PlaySpawnSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLogic.active)
        {
            animator.speed = 1;
            healthBar.SetHealth(lives);
            if (enemyAtt.isFly && alive)
            {
                Fly();
            }
            else if (alive)
            {
                Walk();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.speed = 0;
        }
    }

    //move the enemy to the slime direction
    public void Walk()
    {
        rb.velocity = Vector2.right * enemyAtt.velocity * slimeDirection;
        if (grounded && rb.velocity.y > 0)
        {
            rb.velocity = Vector2.up * enemyAtt.velocity * 3;
        }
    }

    //move a flying enemy to the slime direction with a vertical motion
    public void Fly()
    {
        rb.velocity = Vector2.right * enemyAtt.velocity * slimeDirection;
        y = transform.position.y;
        //apply vertical movement
        if (y > inY + enemyAtt.verticalBound)
        {
            verticalDirection = -1;
        }
        else if (y < inY - enemyAtt.verticalBound)
        {
            verticalDirection = 1;
        }
        transform.Translate(0, enemyAtt.verticalVelocity * verticalDirection * Time.deltaTime, 0);
    }

    //reduse health and trigger hit animation when taking damage
    public void Hit(float dmg)
    {
        lives -= dmg;
        sound.PlayHitSound();
        animator.SetTrigger("Hit");
        IsDead();
    }


    //Func to activate at the end of hit animation
    public void IsDead()
    {
        if (lives <= 0)
        {
            healthBar.SetHealth(0);
            Dead();
        }
    }

    //when enemy been kiiled stop its motion and trigger animation
    public void Dead()
    {
        GetComponent<Collider2D>().includeLayers = 3;
        alive = false;
        sound.PlayDeathSound();
        rb.velocity = Vector2.zero;
        animator.SetTrigger("Death");
    }


    //Func to activate after the death animation
    public void EnemyKilled()
    {
        em.EnemyDown(enemyAtt.points);
        Instantiate(enemyAtt.smokeEffect, transform.position, transform.rotation);
        int r = Random.Range(0, 10);
        if(r == 8 )
        {
            Instantiate(enemyAtt.powerUpDmg, transform.position, transform.rotation);
        }
        else if(r == 2)
        {
            Instantiate(enemyAtt.powerUpFood, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            rb.gravityScale = 2;
        }
        if(collision.gameObject.tag == "Slime")
        {
            slime.GetComponent<SlimeController>().Hit(enemyAtt.damage);
            Dead();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }

    }
}
