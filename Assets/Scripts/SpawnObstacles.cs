using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    private float startDistance = 10;
    private float yDistance = 5;
    private float WebDistance = 25;
    private float TreeDistance = 8;
    private float WallDistance = 35;
    private float FlyingDistance = 25;
    private float minSpread = 5;
    private float maxSpread = 10;
    private float spawnTreshold = -10;

    private float lastYPositionWeb;
    private float lastYPositionBarrier;
    private float lastYPositionTree;
    private float lastYPositionFlying;
    private float lastYPositionWall;



    public Transform playerTransform;
    public Transform obstaclePrefab;
    public Transform webPrefab;
    public Transform TreePrefab;
    public Transform FlyingEnemy;
    public Transform WallEnemy;

    public float ySpread = 35;
    float lastYPos;
    private float start = -1;

    public TMP_Text canvasText;
    void Start()
    {
        lastYPositionWeb = playerTransform.position.y;
        lastYPositionBarrier = playerTransform.position.y;
        lastYPositionTree = playerTransform.position.y;
        lastYPositionFlying = playerTransform.position.y;
        lastYPositionWall = playerTransform.position.y;
    }


    

    void Update()
    {
        if (lastYPositionWall - playerTransform.position.y > WallDistance)
        {
            float side = Random.Range(0, 10);
            if (side <= 5)
            {
                float WallPosx = -11;
                float WallPosZ = 0;
                Instantiate(WallEnemy, new Vector3(WallPosx, playerTransform.position.y - ySpread, WallPosZ), Quaternion.identity);
                lastYPositionWall = playerTransform.position.y;
                return;
            }
            else
            {
                float WallPosx = 11;
                float WallPosZ = 0;
                Instantiate(WallEnemy, new Vector3(WallPosx, playerTransform.position.y - ySpread, WallPosZ), Quaternion.identity);
                lastYPositionWall = playerTransform.position.y;
                return;
            }
        }


        if (lastYPositionFlying - playerTransform.position.y > FlyingDistance)
        {
            float side = Random.Range(0, 10);
            if (side <= 5)
            {
                float FlyingPosx = Random.Range(10, -10);
                float FlyingPosZ = 0;
                Instantiate(FlyingEnemy, new Vector3(FlyingPosx, playerTransform.position.y - ySpread, FlyingPosZ), Quaternion.identity);
                lastYPositionFlying = playerTransform.position.y;
                return;
            }
            else
            {
                float FlyingPosx = Random.Range(10, -10);
                float FlyingPosZ = 0;
                Instantiate(FlyingEnemy, new Vector3(FlyingPosx, playerTransform.position.y - ySpread, FlyingPosZ), Quaternion.identity);
                lastYPositionFlying = playerTransform.position.y;
                return;
            }
        }















        if (lastYPositionTree - playerTransform.position.y > TreeDistance)
        {
            float side = Random.Range(0, 10);
            if (side <= 5)
            {
                float TreePosx = Random.Range(-12, -17);
                float TreePosZ = Random.Range(-7, -13);
                Instantiate(TreePrefab, new Vector3(TreePosx, playerTransform.position.y - ySpread, TreePosZ), Quaternion.identity);
                lastYPositionTree = playerTransform.position.y;
                return;
            }
            else
            {
                float TreePosx = Random.Range(10, 16);
                float TreePosZ = Random.Range(-7, -13);
                Instantiate(TreePrefab, new Vector3(TreePosx, playerTransform.position.y - ySpread, TreePosZ), Quaternion.identity);
                lastYPositionTree = playerTransform.position.y;
                return;
            }
            
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

    private void FixedUpdate()
    {
        float metry = start - playerTransform.position.y;
        metry = Mathf.Round(metry * 100f) / 100f;
        canvasText.text = -metry + "m";
    }












}

