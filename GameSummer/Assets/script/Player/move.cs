using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Transform smoke_point;
    public GameObject smoke_pre;
    public float falling = -0.04f;
    public float jumping = 0.8f;
    public AudioSource jumpAudio;
    public float myHP = 10;
    bool isJump = false;
    float counting = 0f;
    float countJump = 0f;
    private bool checkRun = false;
    public Text txt;

    // FIRE
    public Transform fire_point;
    public GameObject bullet_water;
    public GameObject bullet_mask;
    public AudioSource shoot_Audio;
    private float num_bullet = 1f;
    float count_trigger = 0f;
    // special skill
    float count_skill = 100f;
    bool can_skill = false;
    bool have_button = false;
    public GameObject water_skill;
    public GameObject button_skill;
    public AudioSource skill_Audio;

    public GameObject Heart;
    float count_kira = -1f;
    //public GameObject die_par;
    void Update()
    {
        if (Input.GetKeyDown("f")) {
            changeState();
        }
        if (!checkRun) {
            // UPDATE PLAYER'S HP
            txt.text = myHP.ToString();
            if (transform.position.y > 6f || transform.position.y < -6f)    GameOver();
            // CONTROLL JUMP AND DROP OF PLAYER
            if (Input.GetButtonDown("Jump") && !isJump) {
                jumpAudio.Play(0);
                countJump = 4;
                isJump = true;
                counting = 3;
                outSmoke();
                jumpUp(jumping / 2);
            }
            else if (countJump != 0) {
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
            // CONTROLL SPECIAL SKILL
            if (count_skill == 0f) {
                can_skill = true;
                if (have_button == false) {
                    create_button_skill();
                    have_button = true;
                }
            }
            else count_skill--;
            if (Input.GetKeyDown("s")) {
                if (can_skill) {
                    create_skill();
                    count_skill = 3000f;
                }
            }
            count_trigger--;
            if (count_kira == 0f) kira_kira_heart(1);
            count_kira--;
        }
    }
    public void changeState() {
        checkRun = !checkRun;
    }
    // FUNCTION FOR SKILL AND FIRE BULLET
    void create_button_skill() {
        Instantiate(button_skill, new Vector3(-6.5f,-4f,0f), transform.rotation);
    }
    void create_skill() {
        can_skill = false;
        have_button = false;
        Instantiate(water_skill, new Vector3(-10f,0f,0f), transform.rotation);  
        skill_Audio.Play(0);   
    }
    void shootWater() {
        for (int i = 0; i < num_bullet; i++) {
            Instantiate(bullet_water, fire_point.position, fire_point.rotation);  
            shoot_Audio.Play(0);       
        }
    }
    void shootMask() {
        for (int i = 0; i < num_bullet; i++) {
            Instantiate(bullet_mask, fire_point.position, fire_point.rotation);  
            shoot_Audio.Play(0);       
        }
    }
    // FUNCTION CONTROLL UFO AND EFFECT WHEN JUMPING
    void outSmoke() {
        Instantiate(smoke_pre, smoke_point.position, smoke_point.rotation);
    }
    void jumpUp(float upSize) {
        transform.position = transform.position + new Vector3(0f, upSize, 0f);
    }
    void dropDown() {
        transform.position = transform.position + new Vector3(0f, falling, 0f);
    }
    // ALL WITH TRIGGER UFO
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "virus" || col.gameObject.tag == "human") {
            if (count_trigger <= 0f) {
                Destroy(col.gameObject);
                myHP--;
                Debug.Log(myHP);
                count_trigger = 200f;
                count_kira = 20f;
                kira_kira_heart(0);
            }
        }
        if (col.gameObject.tag == "heal") {
            myHP++;
            Destroy(col.gameObject);
            Debug.Log(myHP);
            count_kira = 20f;
            kira_kira_heart(0);
        }
        if (col.gameObject.tag == "up_bullet") {
            num_bullet++;
            Destroy(col.gameObject);
            Debug.Log(num_bullet);
        }
        if (myHP == 0)    GameOver();
    }
    void GameOver() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        /*  UPDATE LATE
        **  WHEN GAMEOVER, DESTROY UFO
        **  EXPLOSION :))
        */
    }
    void kira_kira_heart(float state_heart) {
        if (state_heart == 1f)
            Heart.SetActive(true);
        else
            Heart.SetActive(false);
    }
}
