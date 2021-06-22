using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    private GameObject player;
    private TextPowerUP powerUpText;
    public float minDistance = 3.0f;
    public AudioSource collectSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpText = GameObject.Find("PowerUpText").GetComponent<TextPowerUP>();
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
                Health h = player.GetComponent<Health>();
                h.CurrentHealth += 20;
                if (h.CurrentHealth > h.MaxHealth)
                    h.CurrentHealth = h.MaxHealth;
                this.transform.parent.gameObject.SetActive(false);
                powerUpText.EnableText("BOOST HEALTH 20", Color.green);
                GameObject.FindGameObjectWithTag("PowerUpsParent").GetComponent<PlacePowerups>().loadNext = true;
            }
        }
        catch
        {
        }
        
    }
}
