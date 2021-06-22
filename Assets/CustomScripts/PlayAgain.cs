using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    private AudioSource selectSound;

    private void Start()
    {
        AudioSource gameOverSound = GameObject.Find("Audio Source(GameOver2)").GetComponent<AudioSource>();
        gameOverSound.Play(0);
        selectSound = GameObject.Find("Audio Source(Select)").GetComponent<AudioSource>();
    }

    public void restartScene()
    {
        selectSound.Play(0);
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        
    }
    
    public void quitGame()
    {
        Application.Quit();
    }
   
}
