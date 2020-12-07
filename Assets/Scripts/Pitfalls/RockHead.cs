using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    [SerializeField] private float speed;
    private float speedCopy;
    [SerializeField] private List<GameObject> points;
    [SerializeField] private int pointsCount;
    [SerializeField] private float restTime;
    private bool isRest;
    private string[] teste = {"top", "bottom", "left", "right"};
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        speedCopy = speed = 2;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        speed += 0.5f;
        if(!isRest)
        {
            if(transform.position == points[pointsCount].transform.position)
            {
                anim.SetTrigger(points[pointsCount].name);
                StartCoroutine(RestTime());
                speed = speedCopy;
                pointsCount += 1;
            }

            if(pointsCount == points.Count)
            {
                pointsCount = 0;
            }
            transform.position = Vector2.MoveTowards(transform.position, points[pointsCount].transform.position, speed * Time.deltaTime);
        }
    }

    IEnumerator RestTime()
    {
        isRest = true;
        yield return new WaitForSeconds(restTime);
        isRest = false;
    }
}
