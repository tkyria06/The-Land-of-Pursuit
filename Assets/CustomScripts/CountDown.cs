using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public bool gameStarted = false;
    private Text textObj;
    private AudioSource numberSound;
    private AudioSource goSound;
    void Start()
    {
        textObj = this.GetComponent<Text>();
        numberSound = GameObject.Find("Audio Source(Number)").GetComponent<AudioSource>();
        goSound = GameObject.Find("Audio Source(Go)").GetComponent<AudioSource>();
        StartCoroutine(Countdown(4));
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            if (count == 1)
            {
                textObj.text = "GO!";
                textObj.color = Color.green;
                goSound.Play(0);
            }
            else
            {
                textObj.text = (count - 1).ToString();
                numberSound.Play(0);
            }
            yield return new WaitForSeconds(1);
            count--;
        }
        // count down is finished...
        StartGame();
    }

    void StartGame()
    {
        gameStarted = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<VehicleControl>().enabled = true;
        textObj.text = "";
    }
}