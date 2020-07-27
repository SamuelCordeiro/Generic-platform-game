using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedEnemy : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    private BoxCollider2D box;
    private CircleCollider2D circle;
    public float speed;
    public Transform rightCollider;
    public Transform leftCollider;
    public Transform headCollider;
    public bool colliding;
    bool playerDestroyed;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
        colliding = Physics2D.Linecast(rightCollider.position, leftCollider.position, layer);
        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;
        }        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - headCollider.position.y;
            if(height > 0 && !playerDestroyed)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");
                box.enabled = false;
                circle.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.35f);
            }
            else
            {
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(collision.gameObject);
            }
        }
    }
}
