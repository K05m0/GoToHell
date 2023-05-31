using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public float startDistance = 10;
    public float yDistance = 15;
    public float WebDistance = 25;
    public float TreeDistance = 8;
    public float WallDistance = 15;
    public float FlyingDistance = 20;
    public float minSpread = 5;
    public float maxSpread = 10;
    public float spawnTreshold = -10;

    private float lastYPositionWeb;
    private float lastYPositionBarrier;
    private float lastYPositionTree;
    private float lastYPositionFlying;
    private float lastYPositionWall;

    private float xWallR = 15;
    private float zWallR = -7;


    private float xWallL = -16;
    private float zWallL = -6;

    private float xWallBack = -0.5f;
    private float zWallBack = -5.2f;

    private float wallTreshold = -200;






    public Transform playerTransform;
    public Transform obstaclePrefab;
    public Transform webPrefab;
    public Transform TreePrefab;
    public Transform FlyingEnemy;
    public Transform WallEnemy;
    public Transform Wall_L;
    public Transform Wall_R;
    public Transform Wall_Back;

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
        if (playerTransform.position.y < wallTreshold)
        {
            Instantiate(Wall_L, new Vector3(xWallL, playerTransform.position.y - 203, zWallL), Quaternion.identity);
            Instantiate(Wall_R, new Vector3(xWallR, playerTransform.position.y - 203, zWallR), Quaternion.identity);
            Instantiate(Wall_Back, new Vector3(xWallBack, playerTransform.position.y - 220, zWallBack), Quaternion.identity);
            wallTreshold = wallTreshold - 150;

        }








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
                float TreePosZ = Random.Range(-11, -14);
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



       
        if (playerTransform.position.y < spawnTreshold)
        {
            
            
            if (lastYPositionBarrier - playerTransform.position.y > yDistance)
            {
                
                float lanePos = Random.Range(-7, 7);
               

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

