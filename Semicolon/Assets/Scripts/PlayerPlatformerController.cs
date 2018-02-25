using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float fMaxSpeed = 7;
    public float fJumpSpeed = 7;
    public int iNumberOfJumpsAllowed = 2;
    private int iNumberOfJumpsTaken = 0;
    public int iCollectables = 0;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool bJump = true;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                iNumberOfJumpsTaken = 0;
                velocity.y = fJumpSpeed;
                Debug.Log("Jumps Taken " + iNumberOfJumpsTaken + " Jumps Allowed " + iNumberOfJumpsAllowed);
                iNumberOfJumpsTaken++;
                bJump = iNumberOfJumpsAllowed > iNumberOfJumpsTaken;
            }
            else if (bJump)
            {
                velocity.y = (0.8f*fJumpSpeed);
                Debug.Log("Jumps Taken " + iNumberOfJumpsTaken + " Jumps Allowed " + iNumberOfJumpsAllowed);
                iNumberOfJumpsTaken++;
                bJump = iNumberOfJumpsAllowed > iNumberOfJumpsTaken;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }


        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / fMaxSpeed);

        targetVelocity = move * fMaxSpeed;
    }
}

