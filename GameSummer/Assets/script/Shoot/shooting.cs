using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform fire_point;
    public GameObject bullet_water;
    public GameObject bullet_mask;
    public AudioSource shoot_Audio;
    private bool checkRun = false;
    
    // USING THIS IN THE GUN AT MAIN MENU
    void Update()
    {
        if (Input.GetKeyDown("f")) {
            if (checkRun) {
                checkRun = false;
            }
            else {
                checkRun = true;
            }
        }
        if (!checkRun) {
            if (Input.GetMouseButtonDown(0)) { // FIRE WATER
                shoot_Audio.Play(0);
                shootWater();
            }
            if (Input.GetMouseButtonDown(1)) { // FIRE MASK
                shoot_Audio.Play(0);
                shootMask();
            }
        }
    }
    void shootWater() {
        Instantiate(bullet_water, fire_point.position, fire_point.rotation);
    }
    void shootMask() {
        Instantiate(bullet_mask, fire_point.position, fire_point.rotation);
    }
}
