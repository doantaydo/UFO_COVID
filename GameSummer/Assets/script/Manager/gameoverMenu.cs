using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    public Text highscore;
    public AudioSource shoot_Audio; 
    float s;
    float hs;
    void Start()
    {
        s = PlayerPrefs.GetFloat("score", 0);
        hs = PlayerPrefs.GetFloat("highscore", 0);
        if (s > hs)
        PlayerPrefs.SetFloat("highscore", s);
        score.text = "YOUR SCORE: " + s.ToString();
        highscore.text = "HIGHSCORE: " + PlayerPrefs.GetFloat("highscore").ToString();
        PlayerPrefs.SetFloat("score", 0);
    }
    void Update() {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
            shoot_Audio.Play(0);
        }
    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void backToMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
