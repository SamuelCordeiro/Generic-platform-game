using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private float speed;
    [SerializeField] private Transform head;
    [SerializeField] private Transform point;
    private GameObject player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(player != null && life > 0)
        {
            point = player.transform;
            transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
            
            if(transform.position.x - point.transform.position.x < 0f)
            {
                transform.eulerAngles = new Vector3(0f,180f,0f);
            }else
            {
                transform.eulerAngles = new Vector3(0f,0f,0f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - head.position.y;
            if(height > 0)
            {
                if(life > 1)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
                    anim.SetTrigger("hit");
                    life --;
                }
                else
                {
                    speed = 0;
                    anim.SetTrigger("hit");
                    gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 5f;
                    //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
                    Destroy(gameObject, 0.35f);
                }
            }
            else
            {
                GameController.instance.ShowGameOver();
                Destroy(collision.gameObject);
            }
        }
    }
}
