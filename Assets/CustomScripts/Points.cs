using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text pointsText;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        pointsText = GetComponent<Text>();
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
    }
}
