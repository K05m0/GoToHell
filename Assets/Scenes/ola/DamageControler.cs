using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControler : MonoBehaviour
{
    public playerhealth Hp;
    private void OnMouseDown()
    {
        Hp.value -= 1;
    }
    
}
