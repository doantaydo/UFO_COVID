using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager_gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    private float point = 0;

    private float count_time_virus = 0f;
    private float time_out_virus = 100f;
    private float num_out_virus = 1f;
    public GameObject obj_Virus1;
    public GameObject obj_Virus2;

    private float count_time_human = 0f;
    private float time_out_human = 100f;
    public GameObject obj_Human1;
    public GameObject obj_Human2;

    public GameObject player;
    private float count_up = 0f;

    public GameObject healer;

    public Text score;
    public Text highscore;

    void Start() {
        highscore.text = "HighScore: " + PlayerPrefs.GetFloat("highscore",0).ToString();
        score.text = "Score: " + point.ToString();
    }

    void FixedUpdate() {
        count_up++;
        // COUTING TO CREATE VIRUS
        if (count_time_virus >= time_out_virus)     count_time_virus = 0;
        count_time_virus++;
        if (count_time_virus == time_out_virus) {
            count_time_virus = 0;
            create_virus();
        }
        // COUTING TO CREATE HUMAN
        if (point > 30) {
            if (count_time_human >= time_out_human)     count_time_human = 0;
            count_time_human++;
            if (count_time_human == time_out_human) {
                count_time_human = 0;
                create_human();
            }
        }
        // UPDATE SCORE
        if (count_up % 100 == 0)    point++;
        score.text = "Score: " + point.ToString();
        PlayerPrefs.SetFloat("score", point);
        // CHECK UPDATE LEVEL GAMEPLAY AND CREATE BUFF
        if (count_up % 2000 == 0)    time_out_virus--;
        if (count_up % 3000 == 0)    time_out_human--;
        if (count_up % 5000 == 0)    num_out_virus++;
        if (count_up % 6000 == 0) {
            count_up = 0;
            create_heal();
        }
    }
    void create_virus() {
        for (int i = 0; i < num_out_virus; i++) {
            if (Random.Range(0f, 10f) < 5f)    Instantiate(obj_Virus1, new Vector3(transform.position.x, (Random.Range(-40f,40f))/10.0f, transform.position.z), transform.rotation);
            else    Instantiate(obj_Virus2, new Vector3(transform.position.x, (Random.Range(-40f,40f))/10.0f, transform.position.z), transform.rotation);
        }
    }
    void create_human() {
        if (Random.Range(0f, 10f) < 5f)    Instantiate(obj_Human1, new Vector3(transform.position.x, -3f, transform.position.z), transform.rotation);
        else    Instantiate(obj_Human2, new Vector3(transform.position.x, -3f, transform.position.z), transform.rotation);
    }
    void create_heal() {
        Instantiate(healer, new Vector3(Random.Range(-20f,100f)/10.0f, 5f, transform.position.z), transform.rotation);
    }
    /*  UPDATE IF IT GOOD
    **  CREATE BUFF TO FIRE MORE BULLET
    **  UP THE SPEED OF VIRUS AND HUMAN
    */  
}
