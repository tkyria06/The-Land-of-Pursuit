using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPowerUP : MonoBehaviour
{
    public Text powerUpText;  //Add reference to UI Text here via the inspector
    private float timeToAppear = 2f;
    private float timeWhenDisappear;
    private bool showing = false;

    void Start()
    {
        powerUpText = this.GetComponent<Text>();
    }

    //Call to enable the text, which also sets the timer
    public void EnableText(string txt, Color color)
    {
        powerUpText.text = txt;
        powerUpText.color = color;
        this.showing = true;
        timeWhenDisappear = Time.time + timeToAppear;
    }

    //We check every frame if the timer has expired and the text should disappear
    void Update()
    {
        if (this.showing && (Time.time >= timeWhenDisappear))
        {
            this.showing = false;
            powerUpText.text = "";
        }
    }
}
