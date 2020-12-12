using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpitter : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject fire;
    [SerializeField] private float onTimer;
    private bool isOn;
    private float time;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        time += Time.deltaTime;
        if(time > onTimer && !isOn)
        {
            fire.GetComponent<BoxCollider2D>().enabled = true;
            time = 0;
            isOn = true;
            anim.SetTrigger("on");
            anim.SetBool("fire", true);
        }
        if(time > onTimer && isOn)
        {
            fire.GetComponent<BoxCollider2D>().enabled = false;
            time = 0;
            isOn = false;
            anim.SetTrigger("off");
            anim.SetBool("fire", false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("hit");
            time = 0;
            isOn = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }
    }
}
