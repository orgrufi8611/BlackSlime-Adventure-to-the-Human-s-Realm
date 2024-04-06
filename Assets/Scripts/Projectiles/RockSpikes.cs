using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpikes : MonoBehaviour
{
    public bool isEnemy;
    float damageOverTime = 2;
    Collider2D colliderBox;
    Animator animator;
    float lastTime;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        animator = GetComponent<Animator>();
        colliderBox = GetComponent<Collider2D>();
        colliderBox.enabled = false;
        animator.enabled = false;
    }

    //method to destroy the objec at the end of an animation
    public void DestroyShpikes()
    {
        Destroy(gameObject);
    }

    //activate the collider to hit enemies mid animation
    public void ActivateCollider()
    {
        colliderBox.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //start the spikes animation when hit the ground
        if (collision.gameObject.tag == "Ground")
        {
            animator.enabled = true;
        }
    }

    //deal damage over time to targets
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isEnemy && collision.gameObject.tag == "Slime")
        {
            if(lastTime < Time.time - 0.1) 
            {
                lastTime = Time.time;
                collision.gameObject.GetComponent<SlimeController>().Hit(damageOverTime);
            }
        }
        else if (!isEnemy && collision.gameObject.tag == "Enemy")
        {
            if (lastTime < Time.time - 0.1)
            {
                lastTime = Time.time;
                collision.gameObject.GetComponent<EnemyMovement>().Hit(damageOverTime);
            }
        }
        else if (!isEnemy && collision.gameObject.tag == "Boss")
        {
            if (lastTime < Time.time - 0.1)
            {
                lastTime = Time.time;
                collision.gameObject.GetComponent<BossBehavior>().Hit(damageOverTime);
            }
        }
    }
}
