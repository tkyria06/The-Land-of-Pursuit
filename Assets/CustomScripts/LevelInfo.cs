using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    public Text levelText;

    void Start()
    {
        levelText = this.GetComponent<Text>();
    }

    //Call to enable the text, which also sets the timer
    public void EnableText(string txt)
    {
        levelText.text = txt;
    }

}
