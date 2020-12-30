using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isGameEnded = false;
    Transform player;
    private void Start() {
        player = GameObject.Find("PlayerObject").transform;
    }
    public void GameOver(){
        if (!isGameEnded)
        {
           
        }
    }

    private void Update() {
        if (player.position.y <= -3)
            {
                Restart();
            }
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GameOverMsg(){

    }

    public bool getIsEnded(){
        return isGameEnded;
    } 
}