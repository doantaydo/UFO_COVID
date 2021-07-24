using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_victim : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject victim_die;
    public GameObject eff;
    private float speed_human = -0.15f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(speed_human, 0f, 0f);
    }
    void OnTriggerEnter2D(Collider2D col) {  
        if (col.gameObject.tag == "bullet_mask" || col.gameObject.tag == "bullet_water_skill") {
            Destroy(gameObject);
            Instantiate(eff, transform.position, transform.rotation);
            Instantiate(victim_die, transform.position, transform.rotation);
        }
        if (col.gameObject.tag == "bullet_water" || col.gameObject.tag == "bullet_mask") Destroy(col.gameObject);
    }
}
