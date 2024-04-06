
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    
    public float slimeDirection;
    
    
    bool init;
    
    //physics parameters
    bool grounded;
    int jumps;
    float timepass;
    float normalGravity, glidingGravity;
    float cooldownFactor;
    public Rigidbody2D rb;
    
    //powerUp managment
    float timepassPowerUp, cooldownPewerUp;
    bool doubleDmg;
    
    public float abilityTime;
    public bool differentState;


    public SlimeSO slimeState;
    public SlimeSO basicSlime;

    public Transform startPos;

    public GameLogic gameLogic;

    Animator animator;

    public SoundPlayerSlime sound;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        differentState = false;
        doubleDmg = false;
        cooldownFactor = 1;
        animator = GetComponent<Animator>();
        init = false;
        normalGravity = 4;
        glidingGravity = normalGravity/16;
        transform.localScale = new Vector2(slimeState.sizeX, slimeState.sizeY);
        timepass = 0;
        rb.gravityScale = 10;
        sound.audioS.volume = 0.1f;
        slimeDirection = 1;
        rb.velocity = Vector2.zero;
        abilityTime = 0;
    }

    public void ResetOnNewScene()
    {
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        //initiate spawning location
        if (!init)
        {
            cooldownFactor = 1 - (gameLogic.lvl - 1) / 5;
            transform.position = new Vector3(ScreenSize.screenUnitWidth/4* GetComponent<SpriteRenderer>().sprite.bounds.size.x,1,0);
            init = true;
        }
        if (gameLogic.active)
        {
            animator.speed = 1;
            timepassPowerUp += Time.deltaTime;
            timepass += Time.deltaTime;
            abilityTime += Time.deltaTime;
            if (timepassPowerUp > cooldownPewerUp)
            {
                doubleDmg = false;
            }

            if (grounded && rb.velocity.y > 0)
            {
                rb.velocity += Vector2.up * Time.deltaTime;
            }
            if(abilityTime > slimeState.abilityCooldown && differentState)
            {
                RevertBack();
            }
            if(slimeState.slimeName == "Slime")
            {
                differentState = false;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.speed = 0;
        }
    }

    //lower the gravity allowing to hover in the air
    public void Glide()
    {
        if(!grounded && rb.velocity.y < 0)
        {
            rb.gravityScale = glidingGravity;
        }
    }

    //return the gravity to normal
    public void StopGliding()
    {
        rb.gravityScale = normalGravity;
    }

    //activating jump animation and check for double jumps
    public void Jump()
    {
        if (!differentState)
        {
            rb.gravityScale = normalGravity;
            if (jumps < 2)
            {
                jumps++;

                if (grounded)
                {
                    sound.PlayJumpSound();
                    grounded = false;
                    animator.SetTrigger("Jump");
                    animator.SetBool("Landed", false);
                }
                else
                {
                    ApplyJump();
                }
            }
        }
    }
    //apply jump
    public void ApplyJump()
    {
        if(rb.velocity.y < 0.1f)
        {
            rb.velocity += Vector2.up *slimeState.jumpVelocity;
        }
        else
        {
            rb.velocity += Vector2.up * (slimeState.jumpVelocity - rb.velocity.y);
        }
        animator.SetBool("MidAir",true);
    }

    //move the slime in a given direction
    public void MoveSlime(int direction)
    {
        if(direction != 0)
        {
            slimeDirection = direction;
            sound.walking = true;
            animator.SetBool("Walking", true);
            transform.localScale = new Vector2(slimeState.sizeX * direction,slimeState.sizeY);
        }
        else
        {
            sound.walking = false;
            animator.SetBool("Walking", false);
        }
        rb.velocity = new Vector2(slimeState.velocity * direction,rb.velocity.y);
    }

    //taking a hit
    public void Hit(float dmg)
    {
        gameLogic.ReduceHealth(dmg);
    }

    // instantiate a shot
    public void Shot()
    {
        if (timepass > slimeState.shootCooldown * cooldownFactor)
        {
            timepass = 0;
            if (slimeState.slimeName == "Slime")
            {
                CreateShot();
            }
            else
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    void CreateShot()
    {
        int times = 1;
        if (doubleDmg)
        {
            times = 2;
        }
        for (int i = 0; i < times; i++)
        {
            GameObject shot = Instantiate(slimeState.shotPrefub, transform.position, transform.rotation);
            shot.GetComponent<Shoot>().damage = slimeState.damage;
            shot.layer = 7;
            shot.GetComponent<Shoot>().isEnemy = false;
        }
    }
    
    //make the slime deal double damage
    public void DoubleDmg()
    {
        cooldownPewerUp = 3;
        timepassPowerUp = 0;
        doubleDmg = true;
    }

    //change slime state with ability
    public void ChangeSlimeState(SlimeSO newState)
    {
        differentState = true;
        slimeState = newState;
        abilityTime = 0;
        animator.SetTrigger(newState.slimeName);
        transform.localScale = new Vector2(slimeState.sizeX, slimeState.sizeY);
    }

    public void RevertBack()
    {
        differentState = false;
        slimeState = basicSlime;
        transform.localScale = new Vector2(slimeState.sizeX, slimeState.sizeY);
        animator.SetTrigger("Revert");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            rb.gravityScale = normalGravity;
            grounded = true;
            jumps = 0;
            animator.SetBool("Landed", true);
            animator.SetBool("MidAir",false);
        }
    }
}
