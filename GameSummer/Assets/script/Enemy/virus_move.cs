using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virus_move : MonoBehaviour
{
    public GameObject myEffect;
    public float speed_virus = -0.15f;
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(speed_virus, 0f, 0f);
    }
    void OnTriggerEnter2D(Collider2D col) {
        
        if (col.gameObject.tag == "bullet_water" || col.gameObject.tag == "bullet_water_skill") {
            Destroy(gameObject);
            Instantiate(myEffect, transform.position, transform.rotation);
        }
        if (col.gameObject.tag == "bullet_mask" || col.gameObject.tag == "bullet_water") Destroy(col.gameObject);
    }
}
