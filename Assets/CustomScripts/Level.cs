using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Text levelText;
    public int level;
    private LevelInfo levelInfo;

    // Start is called before the first frame update
    void Start()
    {
        levelText = GetComponent<Text>();
        level = 1;
        levelInfo = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        int time = Mathf.RoundToInt(Time.timeSinceLevelLoad - 3);
        if (time >= 0 && time <= 60)
        {
            levelText.text = "1";
            level = 1;
            levelInfo.EnableText("Points X1 / Missile Damage " + (5 * level));
        }
        else if (time > 60 && time <= 120)
        {
            levelText.text = "2";
            level = 2;
            levelInfo.EnableText("Points X2 / Missile Damage " + (5 * level));
        }
        else if (time > 120)
        {
            levelText.text = "3";
            level = 3;
            levelInfo.EnableText("Points X3 / Missile Damage " + (5 * level));
        }
        else { }
    }
}
