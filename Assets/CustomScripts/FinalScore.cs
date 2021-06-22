using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        int time = int.Parse(Mathf.RoundToInt(Time.timeSinceLevelLoad-3).ToString());
        timeText.text = time.ToString() + " sec";
        int points = GameObject.FindGameObjectWithTag("points").GetComponent<Points>().points;
        GameObject.Find("PointsEnd").GetComponent<Text>().text = points.ToString();
        int currentScore = points + time;
        GameObject.Find("FinalScore").GetComponent<Text>().text = currentScore.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        bool gotNewHighScore = currentScore > highScore;

        if (gotNewHighScore)
        {
             PlayerPrefs.SetInt("HighScore", currentScore);
             PlayerPrefs.Save();
        }
        GameObject.Find("BestScore").GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

 
}