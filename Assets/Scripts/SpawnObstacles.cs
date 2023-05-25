using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObstacles : PlayerMovement
{
    private float startDistance = 10;
    private float yDistance = 5;
    private float WebDistance = 25;
    private float TreeDistance = 20;
    private float minSpread = 5;
    private float maxSpread = 10;
    private float spawnTreshold = -10;

    private float lastYPositionWeb;
    private float lastYPositionBarrier;
    private float lastYPositionTree;
    


    public Transform playerTransform;
    public Transform obstaclePrefab;
    public Transform webPrefab;
    public Transform TreePrefab;

    public float ySpread = 25;
    float lastYPos;

    void Start()
    {

        lastYPositionWeb = playerTransform.position.y;
        lastYPositionBarrier = playerTransform.position.y;
        lastYPositionTree = playerTransform.position.y;
    }


    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (lastYPositionTree - playerTransform.position.y > TreeDistance)
        {
            float WebPosx = Random.Range(3, -4);
            float webPosZ = Random.Range(24, 7);
            Instantiate(TreePrefab, new Vector3(WebPosx, playerTransform.position.y - ySpread, webPosZ), Quaternion.identity);
            lastYPositionTree = playerTransform.position.y;
        }







            if (lastYPositionWeb - playerTransform.position.y > WebDistance)
        {
            float WebPosx = Random.Range(3, -4);
            float webPosZ = Random.Range(24, 7);
            Instantiate(webPrefab, new Vector3(WebPosx, playerTransform.position.y - ySpread, webPosZ), Quaternion.identity);
            lastYPositionWeb = playerTransform.position.y;
        }



        // Ta Teleportacja na góre odbywaæ sie bedzie przy sklepikarzu, bedzie ³atwiej 
        if (playerTransform.position.y < spawnTreshold)
        {
            //Debug.Log("1");
            //Debug.Log("lastYPosition :" + lastYPosition + " playerTransform.position.y :" + playerTransform.position.y + " yDistance :" + yDistance);
            
            
            if (lastYPositionBarrier - playerTransform.position.y > yDistance)
            {
                //Debug.Log("2");
                float lanePos = Random.Range(-7, 7);
               // ySpread = Random.Range(minSpread, maxSpread);

                Instantiate(obstaclePrefab, new Vector3(lanePos, playerTransform.position.y - ySpread, 0), Quaternion.identity);




                lastYPositionBarrier = playerTransform.position.y;
            }


        }

    }
}

