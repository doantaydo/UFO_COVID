using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start() {
        Screen.SetResolution(1280, 720, false);
    }
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void HowToPlay() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
