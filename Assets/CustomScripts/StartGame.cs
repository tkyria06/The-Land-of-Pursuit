using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private AudioSource selectSound;
    private void Start()
    {
        selectSound = GameObject.Find("Audio Source(Select)").GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        selectSound.Play(0);
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        selectSound.Play(0);
        Application.Quit();
    }
}
