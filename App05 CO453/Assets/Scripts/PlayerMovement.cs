using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private float dirX = 0f;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private bool doubleJump;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 7f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    


    // Start is called before the first frame update
    private void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();   
    }

    // Update is called once per frame
    public void Update()

    {
        MovementState state;
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            
        // Jumping
        //

        if (Input.GetKeyDown("w") && IsGrounded())
        {
            rb.velocity = new Vector3 (rb.velocity.x, jumpForce, 0);
            doubleJump = false;

            jumpSoundEffect.Play();

        }

        // Double Jumping 
        //

        if (Input.GetKeyDown("w"))   
        {
            if(IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = !doubleJump;
            }


        }

        // Running
        //

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        // jumping 
        //

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
        
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
