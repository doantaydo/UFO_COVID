using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controll_Bum : MonoBehaviour
{
    public GameObject red1;
    public GameObject red2;
    public GameObject yel1;
    public GameObject yel2;
    private float count_time = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        count_time++;
        red1.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        red2.transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);
        yel1.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        yel2.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        if (count_time == 5)    Destroy(gameObject);
    }
}
