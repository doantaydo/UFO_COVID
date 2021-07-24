using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_victim : MonoBehaviour
{
    // Start is called before the first frame update
    private float count_time = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count_time < 5) transform.position = transform.position + new Vector3(0.5f, 0.2f, 0f);
        else transform.position = transform.position + new Vector3(0.5f, -0.1f, 0f);
        count_time++;
    }
}
