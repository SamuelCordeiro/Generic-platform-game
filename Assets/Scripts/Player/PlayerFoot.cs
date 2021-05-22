using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    private bool isGrounded;
    private bool isDead;
    private bool isBlowing;
    private bool isJumping;

    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public bool IsBlowing { get => isBlowing; set => isBlowing = value; }
    public bool IsJumping { get => isJumping; set => isJumping = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            IsGrounded = true;
            IsJumping = false;
        }

        if (collision.gameObject.tag == "Pitfalls")
        {
            IsDead = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            IsGrounded = false;
            IsJumping = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Fan")
        {
            IsBlowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Fan")
        {
            IsBlowing = false;
        }
    }
}
