using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    // public float speed;
    // public float moveTime;
    // private bool directionRight;
    // private float timer;
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> points;
    [SerializeField] private int pointsCount;
    [SerializeField] private List<int> flipPoints;
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        // if(directionRight)
        // {
        //     transform.Translate(Vector2.right * speed * Time.deltaTime);
        //     transform.eulerAngles = new Vector3(0f,0f,0f);
        // }
        // else
        // {
        //     //transform.Translate(Vector2.left * speed * Time.deltaTime);
        //     transform.eulerAngles = new Vector3(0f,180f,0f);
        // }
        // transform.Translate(Vector2.right * speed * Time.deltaTime);
        // timer += Time.deltaTime;
        // if(timer >= moveTime)
        // {
        //     directionRight = !directionRight;
        //     timer = 0f;
        // }
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[pointsCount].position, speed * Time.deltaTime);
        
        if(transform.position == points[pointsCount].transform.position)
        {
            
            pointsCount += 1; 
            flip(); 
            //transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(pointsCount == points.Count)
        {
            pointsCount = 0;
            //transform.eulerAngles = new Vector3(0f,180f,0f);
        }
    }

    void flip()
    {
       if(flipPoints.Contains(pointsCount))
        {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        } 
    }
}
