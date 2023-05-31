using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    float destructionTime = 5;

    private PlayerMovement playerMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce((GameObject.FindGameObjectWithTag("BulletTransform").transform.position - transform.position) * force, ForceMode.VelocityChange);

        playerMovement = FindObjectOfType<PlayerMovement>();

        Vector3 kickbackDirection = -transform.forward; // Adjust the kickback direction as needed
        playerMovement.ApplyKickbackForce(kickbackDirection * playerMovement.kickbackForce);
    }

    private void Update()
    {
        
        Destroy(gameObject, destructionTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.ammoCount++;
            Debug.Log("Ammo Count: " + playerMovement.ammoCount);
           // Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Bullet")) // Check collision with other bullets
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}