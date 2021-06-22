using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePowerups : MonoBehaviour
{
    Vector3[,] points;
    GameObject healthUp;
    GameObject healthDown;
    GameObject earnPoints;
    GameObject forceField;
    List<GameObject> healthUpTemp;
    List<GameObject> healthDownTemp;
    List<GameObject> earnPointsTemp;
    List<GameObject> fieldTemp;
    public bool fieldEnabled = false;

    private int activeRow = 0;
    public bool loadNext = true;

    // Start is called before the first frame update
    void Start()
    {
        healthUp = GameObject.Find("HealthIncrease").transform.GetChild(0).gameObject;
        healthDown = GameObject.Find("HealthDecrease").transform.GetChild(0).gameObject;
        earnPoints = GameObject.Find("EarnPoints").transform.GetChild(0).gameObject;
        forceField = GameObject.Find("ForceField").transform.GetChild(0).gameObject;

        healthUpTemp = new List<GameObject>();
        healthDownTemp = new List<GameObject>();
        earnPointsTemp = new List<GameObject>();
        fieldTemp = new List<GameObject>();

        points = new Vector3[,] { { new Vector3(-118.17f, 65.05441f, 34.43f), new Vector3(-118.17f, 65.05441f, 30f), new Vector3(-118.17f, 65.05441f, 25.5f) },
                                  { new Vector3(-18.17f, 51.05441f, 38.43f), new Vector3(-18.17f, 51.05441f, 33.6f), new Vector3(-18.17f, 51.05441f, 28.5f) },
                                  { new Vector3(228.53f, 50.79f, 300.7f), new Vector3(233.53f, 50.79f, 300.7f), new Vector3(238.53f, 50.79f, 300.7f) },
                                  { new Vector3(131.65f, 41.62f, 234.7f), new Vector3(128.53f, 41.62f, 231.31f), new Vector3(123.53f, 41.79f, 229.4f) },
                                  { new Vector3(-116f, 40.75f, 376.2f), new Vector3(-111.2f, 40.75f, 376.2f), new Vector3(-106.2f, 40.75f, 376.2f) },
                                  { new Vector3(-285.57f, 72.08f, 213.3f), new Vector3(-291F, 72.08f, 213.3f), new Vector3(-296.57f, 72.08f, 213.3f) }
                                 };
    }

    // Update is called once per frame
    void Update()
    {
        if (loadNext == true)
        {
            clearOldPowers();
            loadNext = false;

            var list = new List<int> { 0, 1, 2 };
            var listPowers = new List<int> { 0, 1, 2, 3};

            int listLen = list.Count;
            int listPowerLen = listPowers.Count;

            for (int i=0; i<listLen; i++) {
                int index = list[Random.Range(0, list.Count)];
                randomPower(Random.Range(0, listPowers.Count), index);
                list.Remove(index);
            }

            activeRow++;
            if (activeRow == points.GetLength(0))
                activeRow = 0;
        }
    }
    
    private void clearOldPowers()
    {
        foreach (GameObject obj in healthUpTemp)
            if (obj != null)
                Destroy(obj);
        foreach (GameObject obj in healthDownTemp)
            if (obj != null)
                Destroy(obj);
        foreach (GameObject obj in earnPointsTemp)
            if (obj != null)
                Destroy(obj);
        foreach (GameObject obj in fieldTemp)
            if (obj != null)
                if(fieldEnabled == false)
                    Destroy(obj);
    }

    private void randomPower(int value, int index)
    {
        switch (value)
        {
            case 0:
                initializeHealthUp(index);
                break;
            case 1:
                initializeHealthDown(index);
                break;
            case 2:
                initializeField(index);
                break;
            case 3:
                initializeEarnPoints(index);
                break;
        }
        return;
    }

    private void initializeHealthUp(int index)
    {
        GameObject temp = Instantiate(healthUp, Vector3.zero, transform.rotation) as GameObject;
        temp.transform.SetParent(GameObject.FindGameObjectWithTag("PowerUpsParent").transform);
        temp.transform.localPosition = points[activeRow, index];
        temp.SetActive(true);
        healthUpTemp.Add(temp);
        return;
    }
    private void initializeHealthDown(int index)
    {
        GameObject temp = Instantiate(healthDown, Vector3.zero, transform.rotation) as GameObject;
        temp.transform.SetParent(GameObject.FindGameObjectWithTag("PowerUpsParent").transform);
        temp.transform.localPosition = points[activeRow, index];
        temp.SetActive(true);
        healthDownTemp.Add(temp);
        return;
    }
    private void initializeEarnPoints(int index)
    {
        GameObject temp = Instantiate(earnPoints, Vector3.zero, transform.rotation) as GameObject;
        temp.transform.SetParent(GameObject.FindGameObjectWithTag("PowerUpsParent").transform);
        temp.transform.localPosition = points[activeRow, index];
        temp.SetActive(true);
        earnPointsTemp.Add(temp);
        return;
    }
    private void initializeField(int index)
    {
        if (fieldEnabled == false)
        {
            GameObject temp = Instantiate(forceField, Vector3.zero, transform.rotation) as GameObject;
            temp.transform.SetParent(GameObject.FindGameObjectWithTag("PowerUpsParent").transform);
            temp.transform.localPosition = points[activeRow, index];
            temp.SetActive(true);
            fieldTemp.Add(temp);
        }
        else
        {
            initializeEarnPoints(index);
        }
        return;
    }
}

