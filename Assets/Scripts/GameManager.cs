using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isGameEnded = false;
    GameObject[] enemies;

    Animator gameOverAnim;
    private void Start() {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        gameOverAnim = GameObject.Find("TransitionScreen").transform.GetComponent<Animator>();
    }
    public void GameOver(){
        gameOverAnim.SetTrigger("GameOver");//trigger fade out animation)
    }

    public void LoadGameOverScene(){//use when gameoverAnim is ended
        SceneManager.LoadScene("GameOver");
    } 

    private void Update() {
        if(enemies.Length == 0){
            GameOver();//if enemies are 0 game over 
        }
    }
}