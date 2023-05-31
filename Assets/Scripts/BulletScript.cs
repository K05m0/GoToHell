using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    
    public float force;
    


    void Start()
    {   

        GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce((GameObject.FindGameObjectWithTag("BulletTransform").transform.position - transform.position) * force, ForceMode.VelocityChange);
        //Debug.Log((GameObject.FindGameObjectWithTag("BulletTransform").transform.position - transform.position) * force);

    }

    // Update is called once per frame
    void Update()
    {
        float destructionTime = 10;
        Destroy(gameObject, destructionTime);


    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
    }
}


