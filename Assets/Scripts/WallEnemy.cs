using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEnemy : MonoBehaviour
{
    public Vector3Value target;
    private Vector3 startPosition;
    public int health = 1;


    void Start()
    {
        transform.DOMoveY(20f, 2f).SetRelative(true).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutExpo);


    }
    void OnTriggerEnter(Collider collision)
    {
      if (collision.gameObject.tag == "Bullet")
      {
           health--;
      }
    }



    void Update()
    {


        if (health <= 0)
        {
            Destroy(gameObject);
        }

        // transform.position = new Vector3(startPosition.x, target.position.y, startPosition.z) * step;
        // transform.Translate = (new Vector3(0, target.position.y, 0) * step);
        // transform.DOMoveZ
        //Debug.Log(target.position.y);
    }


    //Debug.Log(target.position);
    //Debug.DrawLine(target.position, startPosition);
    //transform.Translate(target.position * Time.deltaTime);
}
