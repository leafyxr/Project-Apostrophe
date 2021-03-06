﻿using System.Collections;
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
    GameObject eventBox;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool bJump = true;
    private int MaxHealth = 5;
    public int CurrentHealth;
    public float fallTime = 0.3f;//Default fall time & speed causes damage after falling 5 tiles
    private float airTime;
    public float maxFallSpeed = 7;
    private bool paused;
    public AudioClip walk;
    public AudioClip jump;
    public AudioClip healthup;
    public AudioClip itemup;
    public AudioClip damaged;

    private void OnLevelWasLoaded(int level)
    {
        Time.timeScale = 1;
    }
    void Awake()//Start
    {
        Application.targetFrameRate = 30;
        paused = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        CurrentHealth = MaxHealth;
    }

    protected override void ComputeVelocity()//Update
    {
        if (Input.GetButtonDown("Pause"))
        {
            
            paused = !paused;
            eventBox.SetActive(true);
            eventBox.GetComponent<EventBox>().pauseGame(paused);
            if (!paused)
            {
                eventBox.SetActive(false);
            }
            
        }
        Vector2 move = Vector2.zero;//default move speed if no input

        move.x = Input.GetAxis("Horizontal");//move speed altered by horizontal inputs
        if (move.x != 0 && !GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().PlayOneShot(walk);
        }
        if (Input.GetButtonDown("Jump"))//if jump input pressed
        {
            
            if (grounded)//when start on ground
            {
                
                GetComponent<AudioSource>().PlayOneShot(jump);
                iNumberOfJumpsTaken = 0;//no jump taken
                velocity.y = fJumpSpeed;//launch
                iNumberOfJumpsTaken++;
                bJump = iNumberOfJumpsAllowed > iNumberOfJumpsTaken;
            }
            else if (bJump)// if not grounded and no reached maximum jumps
            {
                
                GetComponent<AudioSource>().PlayOneShot(jump);
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
                takeDamage(Mathf.RoundToInt(airTime/fallTime));
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

    public void takeDamage(int iDamage)
    {
        GetComponent<AudioSource>().PlayOneShot(damaged);
        CurrentHealth =CurrentHealth-iDamage;
        if (CurrentHealth <= 0)
        {
            eventBox.SetActive(true);
            eventBox.GetComponent<EventBox>().SendMessage("gameOver");
        }
    }

    void getCollectable()
    {
        GetComponent<AudioSource>().PlayOneShot(healthup);
        iCollectables++;
    }
    public void healthPickup()
    {
        GetComponent<AudioSource>().PlayOneShot(itemup);
        if (CurrentHealth < 5)
        {
            CurrentHealth++;
        }
    }
    
}

