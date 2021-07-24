using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_V1_m : MonoBehaviour
{
    public float speed_virus = -0.15f;
    public GameObject myEffect;
    void Update()
    {
        transform.position = transform.position + new Vector3(0f, speed_virus, 0f);
    }
    void OnTriggerEnter2D(Collider2D col) {
        
        if (col.gameObject.tag == "bullet_water") {
            Destroy(gameObject);
            Instantiate(myEffect, transform.position, transform.rotation);
        }
        if (col.gameObject.tag != "Player") Destroy(col.gameObject);
    }
}
