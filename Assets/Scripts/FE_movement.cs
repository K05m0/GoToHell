using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FE_movement : MonoBehaviour
{
    public int health = 1;
    public float DMG;
    public GameObject player;
    void Start()
    {
        transform.DOMoveX(6f, 2f).SetRelative(true).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutExpo);
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

}
