using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObstacles : PlayerMovement
{
    public float startDistance = 10;
    public float yDistance = 5;
    public float minSpread = 5;
    public float maxSpread = 10;
    public float spawnTreshold = -10;
    private float yPosition;
    


    public Transform playerTransform;
    public Transform obstaclePrefab;

    float ySpread;
    float lastYPos;

    void Start()
    {

        lastYPosition = playerTransform.position.y;
    }

    void Update()
    {
        // Ta Teleportacja na góre odbywaæ sie bedzie przy sklepikarzu, bedzie ³atwiej 
        if (playerTransform.position.y < spawnTreshold)
        {
            //Debug.Log("1");
            //Debug.Log("lastYPosition :" + lastYPosition + " playerTransform.position.y :" + playerTransform.position.y + " yDistance :" + yDistance);
            
            
            if (lastYPosition - playerTransform.position.y > yDistance)
            {
                //Debug.Log("2");
                float lanePos = Random.Range(-7, 7);
                ySpread = Random.Range(minSpread, maxSpread);

                Instantiate(obstaclePrefab, new Vector3(lanePos, playerTransform.position.y - ySpread, 0), Quaternion.identity);


                lastYPosition = playerTransform.transform.position.y;


            }
        }

    }
}

