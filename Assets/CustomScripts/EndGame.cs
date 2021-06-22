using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Audio Source(Heli)").GetComponent<AudioSource>().Stop();
        GameObject pointsObj = GameObject.Find("Points");
        GameObject pointsTitleObj = GameObject.Find("PointsTitle");
        try
        {
            int points = Convert.ToInt32(pointsObj.GetComponent<Text>().ToString());
        }
        catch
        {
            return;
        }
        pointsObj.SetActive(false);
        pointsTitleObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
