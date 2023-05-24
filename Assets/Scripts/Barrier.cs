using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private Transform Player;
    
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        //if (distance > 40)
        //{
        //    Destroy(gameObject);
        //   idk ale wywala errory tak¿e zostaje w //
        //}


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
