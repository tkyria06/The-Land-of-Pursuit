using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnPoints : MonoBehaviour
{
    private GameObject player;
    private TextPowerUP powerUpText;
    public float minDistance = 3.0f;
    public Points pointsComp;
    public int pointValue = 0;
    public AudioSource collectSound;
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpText = GameObject.Find("PowerUpText").GetComponent<TextPowerUP>();
        pointsComp = GameObject.FindGameObjectWithTag("points").GetComponent<Points>();
        var pointsList = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70 , 75, 80, 85, 90 ,95 ,100};
        pointValue = pointsList[Random.Range(0, pointsList.Count)];
        collectSound = GameObject.Find("Audio Source(PowerUp)").GetComponent<AudioSource>();
        level = GameObject.Find("Level").GetComponent<Level>().level;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= minDistance)
            {
                collectSound.Play(0);
                Debug.Log("Earn Points");
                pointsComp.points += (pointValue * level);
                this.transform.parent.gameObject.SetActive(false);
                powerUpText.EnableText("+"+(pointValue * level)+" POINTS EARNED", Color.yellow);
                GameObject.FindGameObjectWithTag("PowerUpsParent").GetComponent<PlacePowerups>().loadNext = true;
            }
        }
        catch
        {
        }
    }
}
