using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    private GameObject player;
    private TextPowerUP powerUpText;
    public float minDistance = 3.0f;
    private GameObject field;
    public AudioSource collectSound;
    Health h;    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpText = GameObject.Find("PowerUpText").GetComponent<TextPowerUP>();
        h = player.GetComponent<Health>();
        field = player.transform.Find("ForceFieldPlayer").gameObject;
        collectSound = GameObject.Find("Audio Source(PowerUp)").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= minDistance)
            {
                collectSound.Play(0);
                this.GetComponent<Renderer>().enabled = false;
                Debug.Log("Force Field");
                field.SetActive(true);

                h.gettingDamage = false;

                this.transform.parent.gameObject.SetActive(false);
                powerUpText.EnableText("FORCEFIELD ENABLED", Color.blue);
                Invoke("ForceFieldOff", 7);
                GameObject.FindGameObjectWithTag("PowerUpsParent").GetComponent<PlacePowerups>().loadNext = true;
                GameObject.FindGameObjectWithTag("PowerUpsParent").GetComponent<PlacePowerups>().fieldEnabled = true;
            }

            if (field.activeSelf == false)
                h.gettingDamage = true;
        }
        catch
        {
            return;
        }
    }

    private void ForceFieldOff()
    {
        try
        {
            field.SetActive(false);
            h.gettingDamage = true;
            GameObject.FindGameObjectWithTag("PowerUpsParent").GetComponent<PlacePowerups>().fieldEnabled = false;
        }
        catch
        {
            return;
        }
        
    }

    
}
