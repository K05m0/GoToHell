using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FE_movement : PlayerMovement
{
    public float DMG;
    public GameObject player;
    void Start()
    {
        transform.DOMoveX(6f, 2f).SetRelative(true).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutExpo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HP = HP - DMG;
            Demage();
            Debug.Log(HP);
        }
    }
}
