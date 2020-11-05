using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedEnemy : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private float speed;
    [SerializeField] private Transform head;
    [SerializeField] private List<Transform> points;
    [SerializeField] private int pointsCount;
    private Rigidbody2D rig;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        life = 2;
        rig = GetComponent<Rigidbody2D>();
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
        transform.position = Vector2.MoveTowards(transform.position, points[pointsCount].position, speed * Time.deltaTime);
        
        if(transform.position == points[pointsCount].transform.position)
        {
            pointsCount += 1;  
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(pointsCount == points.Count)
        {
            pointsCount = 0;
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - head.position.y;
            if(height > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");
                Destroy(gameObject, 0.35f);
            }
            else
            {
                GameController.instance.ShowGameOver();
                Destroy(collision.gameObject);
            }
        }
    }
}
