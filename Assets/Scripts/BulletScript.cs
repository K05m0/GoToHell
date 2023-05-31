using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    public float force;

    public PlayerMovement playerMovement;
    public GameObject playerObject;


    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerMovement = playerObject.GetComponent<PlayerMovement>();

        GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce((GameObject.FindGameObjectWithTag("BulletTransform").transform.position - transform.position) * force, ForceMode.VelocityChange);
        //Debug.Log((GameObject.FindGameObjectWithTag("BulletTransform").transform.position - transform.position) * force);

       

    }

    // Update is called once per frame
    void Update()
    {
        float destructionTime = 9999;
        Destroy(gameObject, destructionTime);


    }

    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.ammoCount++;
            Debug.Log("Ammo Count: " + playerMovement.ammoCount);
            Destroy(gameObject);
        }
        
        
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "enemy")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
    }
}


