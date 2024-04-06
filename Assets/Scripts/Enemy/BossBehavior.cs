using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public BossSO boss;
    public Transform shotOrigin;
    public Transform enemySpawner;
    public HealthBar healthBar;
    Animator animator;
    float lives;
    float timepass, spawnTime;
    GameLogic gameLogic;
    // Start is called before the first frame update
    void Start()
    {
        lives = boss.lives;
        timepass = 0;
        spawnTime = 0;
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth(lives);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLogic.active)
        {
            animator.speed = 1;
            healthBar.SetHealth(lives);
            spawnTime += Time.deltaTime;
            timepass += Time.deltaTime;
            if (timepass > boss.attackCooldown) 
            {
                timepass = 0;
                animator.SetTrigger("Attack");
            }
            if(spawnTime > boss.spawnCooldown)
            {
                spawnTime = 0;
                Instantiate(boss.minions,enemySpawner.position,enemySpawner.rotation);
            }
        }
        else
        {
            animator.speed = 0;
        }
    }

    public void Shoot()
    {
        Instantiate(boss.projectilePrefub, shotOrigin.position, shotOrigin.rotation);
    }

    //reduse health and trigger hit animation when taking damage
    public void Hit(float dmg)
    {
        lives -= dmg;
        animator.SetTrigger("Hit");
        IsDead();
    }

    //Func to activate at the end of hit animation
    public void IsDead()
    {
        print("check if boss dead");
        if (lives <= 0)
        {
            Dead();
        }
    }
    //when enemy been kiiled stop its motion and trigger animation
    public void Dead()
    {
        gameLogic.AddPoints(boss.points);
        animator.SetTrigger("Death");
    }

    public void LvlBeaten()
    {
        gameLogic.LevelUp();
    }

}
