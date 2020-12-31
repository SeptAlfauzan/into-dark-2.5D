using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject credit;
    public GameObject buttonMenu;

    private void Start() {
        CloseCredit();
    }
    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void DisplayCredit(){
        buttonMenu.SetActive(false);
        credit.SetActive(true);
    }

    public void CloseCredit(){
        credit.SetActive(false);
        buttonMenu.SetActive(true);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
