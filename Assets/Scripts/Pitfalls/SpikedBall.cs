using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    [SerializeField] private float leftLimit = 0.3f;
    [SerializeField] private float rightLimit = 0.3f;
    [SerializeField] private float speed;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.angularVelocity = 500;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(transform.rotation.z < rightLimit && rig.angularVelocity > 0 && rig.angularVelocity < speed)
        {
            rig.angularVelocity = speed;
        }
        else if(transform.rotation.z > leftLimit && rig.angularVelocity < 0 && rig.angularVelocity > -speed)
        {
            rig.angularVelocity = -speed;
        }
    }
}
