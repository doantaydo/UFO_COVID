using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virus : MonoBehaviour
{
    // Start is called before the first frame update
    private float rota = -0.8f;
    void FixedUpdate()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z += rota;
        transform.rotation = Quaternion.Euler(rotationVector);
    }
    
}
