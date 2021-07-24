using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_check : MonoBehaviour
{

    // Update is called once per frame
    // USE TO DESTROY OBJECT BUTTON WHEN USE SPECAIL SKILL
    /*  UPDATE
    **  BUTTON WILL BE THE OBJECT IN CANVAS
    **  JUST SETACTIVE, DON'T NEED THIS SCRIPT
    */
    void FixedUpdate()
    {
        if (Input.GetKeyDown("s")) {
            Destroy(gameObject);
        }
    }
}
