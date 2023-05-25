using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TreeScript : MonoBehaviour
{
    public Vector3Value playerPosition;

    void Start()
    {




        float rotation = Random.Range(-15, 15);
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerPosition.position);

        if (distance > 40)
        {
            Destroy(gameObject);

        }
    }
}
