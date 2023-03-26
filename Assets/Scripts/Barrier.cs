using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject Player;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*float distance = Vector3.Distance(transform.position, Player.transform.position); 

        if (distance > 40)
        {
            Destroy(gameObject);
        } */


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            
        }
    }
}
