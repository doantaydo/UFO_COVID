using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controll_ufo : MonoBehaviour
{
    public Transform smoke_point;
    public GameObject smoke_pre;
    public float falling = -0.04f;
    public float jumping = 0.8f;
    public AudioSource jumpAudio;
    bool isJump = false;
    float counting = 0f;
    float countJump = 0f;

    // FIRE
    public Transform fire_point;
    public GameObject bullet_water;
    public GameObject bullet_mask;
    public AudioSource shoot_Audio;

    // special skill
    public GameObject water_skill;
    public AudioSource skill_Audio;

    void Update()
    {
            // CONTROLL JUMP AND DROP OF PLAYER
            if (Input.GetButtonDown("Jump") && !isJump && transform.position.y < 1.5) {
                jumpAudio.Play(0);
                countJump = 4;
                isJump = true;
                counting = 3;
                outSmoke();
                jumpUp(jumping / 2);
            }
            else if (countJump != 0 && transform.position.y < 1.5) {
                if (countJump > 3)    jumpUp(jumping);
                else                 jumpUp(jumping / 3);
                countJump--;
            }
            else {
                dropDown();
                counting--;
                if (counting == 0) isJump = false;
            }
            // CONTROLL SHOOT
            if (Input.GetMouseButtonDown(0)) { // FIRE WATER
                shootWater();
            }
            if (Input.GetMouseButtonDown(1)) { // FIRE MASK
                shootMask();
            }
            if (Input.GetKeyDown("s")) {
                create_skill();
            }
    }
    void create_skill() {
        Instantiate(water_skill, new Vector3(-10f,0f,0f), transform.rotation);
        skill_Audio.Play(0);   
    }
    void shootWater() {
            Instantiate(bullet_water, fire_point.position, fire_point.rotation);  
            shoot_Audio.Play(0);       
    }
    void shootMask() {
            Instantiate(bullet_mask, fire_point.position, fire_point.rotation);  
            shoot_Audio.Play(0);
    }

    void outSmoke() {
        Instantiate(smoke_pre, smoke_point.position, smoke_point.rotation);
    }
    void jumpUp(float upSize) {
        transform.position = transform.position + new Vector3(0f, upSize, 0f);
    }
    void dropDown() {
        if (transform.position.y > -2) {
            transform.position = transform.position + new Vector3(0f, falling, 0f);
        }
    }
    
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void BackToMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

}
