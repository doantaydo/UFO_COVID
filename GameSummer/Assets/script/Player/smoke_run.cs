using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke_run : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private float counter = 0;
    private Vector3 scaleChange;

    void Start()
    {
        rb.velocity = transform.right * speed;
        scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale += scaleChange;
        counter++;
        if (counter == 100) {
            Destroy(gameObject);
        }
    }
}
