using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private bool enableRain = true;
    private Light sun;

    private void Awake()
    {
        var list = new List<bool> { true, false };
        enableRain = list[Random.Range(0, list.Count)];
        if (enableRain == false)
        {
            sun = GameObject.Find("Directional Light(Sun)").GetComponent<Light>();
            sun.intensity = 1.0f;
            this.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }
}
