using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rino : MonoBehaviour
{
    private float initialSpeed;
    [SerializeField] private float speed;
    [SerializeField] private int life;
    [SerializeField] private float hitTime;
    [SerializeField] private Transform head;
    [SerializeField] private List<Transform> points;
    [SerializeField] private int pointsCount;
    private bool canWalk;
    private Rigidbody2D rig;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        canWalk = true;
        initialSpeed = speed;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (canWalk)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[pointsCount].position, speed * Time.deltaTime);
            anim.SetBool("run", true);
            if (transform.position == points[pointsCount].transform.position)
            {
                pointsCount += 1;
                anim.SetTrigger("hitWall");
                StartCoroutine(hitWall());
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            if (pointsCount == points.Count)
            {
                pointsCount = 0;
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - head.position.y;
            if (height > 0)
            {
                life--;
                anim.SetTrigger("hit");
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12, ForceMode2D.Impulse);
                if (life <= 0)
                {
                    speed = 0;
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

    IEnumerator hitWall()
    {
        anim.SetBool("run", false);
        speed = 0;
        canWalk = false;
        yield return new WaitForSeconds(hitTime);
        anim.SetBool("run", true);
        speed = initialSpeed;
        canWalk = true;
    }
}
