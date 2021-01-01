using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isGameEnded = false;
    GameObject[] enemies;

    Animator gameOverAnim;
    private void Start() {
        
        gameOverAnim = GameObject.Find("TransitionScreen").transform.GetComponent<Animator>();
    }
    public void GameOver(){
        gameOverAnim.SetTrigger("GameOver");//trigger fade out animation)
    }
    public void Winning(){
        gameOverAnim.SetTrigger("Winning");//trigger fade out animation)
    }

    public void LoadGameOverScene(){//use when gameoverAnim is ended
        SceneManager.LoadScene("GameOver");
    } 
    public void LoadWinningScene(){//use when gameoverAnim is ended
        SceneManager.LoadScene("Winning");
    } 



    private void Update() {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0){
            Winning();//if enemies are 0 game over 
        }
    }
}