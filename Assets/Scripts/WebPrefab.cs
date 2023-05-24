using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WebPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float rotation = Random.Range(1, 360);
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
