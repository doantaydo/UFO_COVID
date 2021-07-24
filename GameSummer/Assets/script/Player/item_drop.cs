using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_drop : MonoBehaviour
{
    private float speed_run = -0.05f; 
    private float speed_drop = -0.03f; 

    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(speed_run, speed_drop, 0f);
    }
}
