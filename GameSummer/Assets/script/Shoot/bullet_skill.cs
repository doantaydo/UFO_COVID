using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_skill : MonoBehaviour
{

    // Update is called once per frame
    private float speed = 0.5f;
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(speed, 0f, 0f);
        if (transform.position.x > 20f)
            Destroy(gameObject);
    }
}
