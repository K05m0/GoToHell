using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Canvas canvas;
    public Camera camera2;

    void Update()
    {


        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        Vector2 mouseOnScreen = (Vector2)camera2.ScreenToViewportPoint(Input.mousePosition);
        Vector2 mouseOnScreenScaled = mouseOnScreen;

        float angle = AngleBetweenTwoPoints(-positionOnScreen, -mouseOnScreenScaled);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        Debug.DrawLine(positionOnScreen, mouseOnScreen, Color.green);
        Debug.DrawLine(-positionOnScreen, -mouseOnScreenScaled, Color.red);
        Debug.Log("mouseOnScreen :" + mouseOnScreen + ", Scaled: " + mouseOnScreenScaled  + " positionOnScreen :" + positionOnScreen);
        Debug.Log("ScaleFactor = " + canvas.scaleFactor);

    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(-a.y - -b.y, a.x - b.x) * -Mathf.Rad2Deg;
    }

}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Camera cameraMouse;
   // private float canvas = Canvas.scaleFactor;
   public Canvas canvas;
    public RectTransform RectTransform;
    private Vector3 mouseOnScreen; 
    
    private void Start()
    {
        
    }

    void Update()
    {
        Vector2 mouseOnScreen = (Vector2)cameraMouse.ScreenToViewportPoint(Input.mousePosition);


        //Vector2 positionOnScreen = Camera.main.WorldToScreenPoint(transform.position);
        // Vector2 positionOnScreen = Input.mousePosition;
        // Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition * 100);
        //RectTransformUtility.ScreenPointToWorldPointInRectangle(RectTransform, positionOnScreen, cameraMouse, out mouseOnScreen);
        // Vector2 mouseOnScreen = (Vector2)cameraMouse.ScreenToViewportPoint(Input.mousePosition);
        //Vector2 mouseOnScreen = positionOnScreen / canvas.scaleFactor;
        Vector2 positionOnScreen = mouseOnScreen / canvas.scaleFactor;
        Debug.DrawLine(positionOnScreen, mouseOnScreen, Color.green);
        Debug.DrawLine(positionOnScreen, -mouseOnScreen, Color.red);
        Debug.Log("mouseOnScreen :" + mouseOnScreen + ", " + "positionOnScreen :" + positionOnScreen);
        Debug.Log("ScaleFactor = " + canvas.scaleFactor);


        float angle = AngleBetweenTwoPoints(positionOnScreen, -mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(-a.y - -b.y, a.x - b.x) * -Mathf.Rad2Deg;
    }

   




 
}
*/