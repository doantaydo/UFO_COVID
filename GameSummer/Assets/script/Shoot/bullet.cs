using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 30f;
    public Rigidbody2D rb;
    private float counter = 0;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter++;
        if (counter == 1000) {
            Destroy(gameObject);
        }
    }
}
