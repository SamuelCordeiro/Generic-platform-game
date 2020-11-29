using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float jumpSpeed;
    [SerializeField]private bool isJumping;
    [SerializeField]private bool doubleJump;
    private bool isBlowing;
    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);
        if(movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(movement == 0)
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isBlowing)
        {
            if(!isJumping)
            {
                rig.velocity = Vector2.up * jumpSpeed;
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if(doubleJump)
                {
                    rig.velocity = Vector2.up * jumpSpeed;
                    doubleJump = false; 
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        // if(collision.gameObject.layer == 8)
        // {
        //     isJumping = false;
        //     anim.SetBool("jump", false);
        // }

        if(collision.gameObject.tag == "Pitfalls")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
        
    }

    void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Fan")
        {
            isBlowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Fan")
        {
            isBlowing = false;
        }
    }
}
