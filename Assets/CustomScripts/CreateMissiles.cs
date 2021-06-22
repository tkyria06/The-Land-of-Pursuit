using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMissiles : MonoBehaviour
{

    private IEnumerator coroutine;
    GameObject missileTemp;
    // Start is called before the first frame update
    void Start()
    {
        missileTemp = GameObject.Find("Gunship").transform.GetChild(0).gameObject;
        coroutine = ScheduleMissiles(7);
        StartCoroutine(coroutine);
    }

    private IEnumerator ScheduleMissiles(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            initializeMissile();
        }
    }

    void initializeMissile()
    {
        Transform heli = GameObject.Find("Hellicopter").transform;
        GameObject temp = Instantiate(missileTemp, Vector3.zero, Quaternion.identity) as GameObject;
        temp.transform.SetParent(GameObject.Find("Missiles").transform);
        temp.transform.position = heli.position;
        temp.transform.localRotation = heli.rotation;
        temp.SetActive(true);
    }
}
