using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public CountDown countDownObj;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        countDownObj = GameObject.Find("CountDown").GetComponent<CountDown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countDownObj.gameStarted)
            timeText.text = Mathf.RoundToInt(Time.timeSinceLevelLoad - 3).ToString();
    }
}
