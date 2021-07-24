using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_delete : MonoBehaviour
{
    // Start is called before the first frame update
    private float counter = 0;
    public float time_die = 500;
    // Update is called once per frame
    void FixedUpdate() {
        counter++;
        if (counter == time_die) {
            Destroy(gameObject);
        }
    }
}
