using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public float shootSpeed = 300;

    private bool playerInRange = false;
    private float lastAttackTime = 0f;
    private float fireRate = 0.5f; //how many bullets are fired/second
    private Transform player = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            playerInRange = true;
            player = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            playerInRange = false;
            player = null;
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            //Rotate the enemy towards the player
            transform.rotation = Quaternion.LookRotation(player.position - transform.position, transform.up);

            if (Time.time - lastAttackTime >= 1f / fireRate)
            {
                shootBullet();
                lastAttackTime = Time.time;
            }
        }
    }

    void shootBullet()
    {

        var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
        //Shoot the Bullet in the forward direction of the player
        projectile.velocity = transform.forward * shootSpeed;
    }
}
