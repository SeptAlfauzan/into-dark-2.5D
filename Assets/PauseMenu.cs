using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPaused = false;
    public GameObject pauseMenu;
    public AudioSource bgMusic;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenu.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
        isPaused = false;
        bgMusic.Play();

    }
    void Pause(){
        pauseMenu.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;//freeze time
        isPaused = true;
        bgMusic.Pause();
    }

    public void MainMenu(){
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Main menu");
    }
}
