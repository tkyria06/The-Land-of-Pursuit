using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject endGameUI;

    public void gameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            //Debug.Log("Game Over");
            Invoke("activeEndUI", 2);
            //Invoke("restart", 2);
        }

        
        
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    void activeEndUI()
    {
        endGameUI.SetActive(true);
        Time.timeScale = 0f;
    }

    
}
