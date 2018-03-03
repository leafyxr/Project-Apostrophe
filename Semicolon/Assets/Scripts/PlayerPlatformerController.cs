using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float fMaxSpeed = 5;
    public float fJumpSpeed = 8.5f;    
    public int iNumberOfJumpsAllowed = 2;
    private int iNumberOfJumpsTaken = 0;
    public int iCollectables = 0;
    [SerializeField]
    GameObject RespawnPoint;
    [SerializeField]
    GameObject eventBox;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool bJump = true;
    private int MaxHealth = 5;
    public int CurrentHealth;
    public float fallTime = 0.3f;//Default fall time & speed causes damage after falling 5 tiles
    private float airTime;
    public float maxFallSpeed = 7;
    void Awake()//Start
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        CurrentHealth = MaxHealth;
    }

    protected override void ComputeVelocity()//Update
    {
        Vector2 move = Vector2.zero;//default move speed if no input

        move.x = Input.GetAxis("Horizontal");//move speed altered by horizontal inputs

        if (Input.GetButtonDown("Jump"))//if jump input pressed
        {
            if (grounded)//when start on ground
            {
                iNumberOfJumpsTaken = 0;//no jump taken
                velocity.y = fJumpSpeed;//launch
                iNumberOfJumpsTaken++;
                bJump = iNumberOfJumpsAllowed > iNumberOfJumpsTaken;
            }
            else if (bJump)// if not grounded and no reached maximum jumps
            {
                velocity.y = (0.8f*fJumpSpeed);//second jump slower than first
                iNumberOfJumpsTaken++;
                bJump = iNumberOfJumpsAllowed > iNumberOfJumpsTaken;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0) : (move.x < 0));//flip sprite when moving in different directions
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        if (move.x == 0 && grounded)//prevents sliding down slopes
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePosition;
        }

        if (grounded)//calculates fall damage
        {
            if (airTime > fallTime)
            {
                takeDamage();
            }
            airTime = 0;
        }
        else if (!grounded && Mathf.Abs(velocity.y) > maxFallSpeed)
        {
            airTime += Time.deltaTime;
        }

        animator.SetBool("grounded", grounded);//Jump Animation
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / fMaxSpeed);//Walking animation

        targetVelocity = move * fMaxSpeed;
    }

    private void takeDamage()
    {
        CurrentHealth--;
        if (CurrentHealth == 0)
        {
            eventBox.SetActive(true);
            eventBox.GetComponent<EventBox>().SendMessage("gameOver");
        }
    }

    void getCollectable()
    {
        iCollectables++;
    }

    private void respawn()
    {
        CurrentHealth = MaxHealth;
        transform.position = RespawnPoint.transform.position;
    }
    
}

