using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_scene_menu : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject obj_Virus;
    private float count = 0f;
    private float time_out = 50f;
    void Update()
    {
        if (time_out == count) {
            count = -1f;
            Instantiate(obj_Virus, transform.position, transform.rotation);
        }
        count++;
        
    }
}
