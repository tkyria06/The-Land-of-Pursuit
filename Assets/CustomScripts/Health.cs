using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public CountDown countDownObj;
    public int MaxHealth = 100;
    public int CurrentHealth;
    public int radius = 5;
    public float force = 700f;
    bool hasExploded = false;
    public bool gettingDamage = true;
    public AudioSource expSound;

    public Healthbar healthbar;
    private Vector3 position;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        countDownObj = GameObject.Find("CountDown").GetComponent<CountDown>();
        CurrentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        position = transform.position;
        expSound = GameObject.Find("Audio Source(GameOver)").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(CurrentHealth);
        if (gettingDamage)
        {
            bool gameStarted = countDownObj.gameStarted;
            if (transform.position == position && gameStarted)
            {
                CurrentHealth -= 1;
                healthbar.SetHealth(CurrentHealth);
            }
            position = transform.position;

            if (CurrentHealth <= 0 && hasExploded == false)
            {
                hasExploded = true;
                Explode();
                Destroy(gameObject);
                FindObjectOfType<GameManager>().gameOver();
                GameObject[] borders = GameObject.FindGameObjectsWithTag("Border");
                Debug.Log(borders);
                borders[0].SetActive(false);
                borders[1].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gettingDamage)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            float speed = rb.velocity.magnitude;
            CurrentHealth -= 1;
            healthbar.SetHealth(CurrentHealth);
        }
    }

    void Explode()
    {
        expSound.Play(0);
        Instantiate(explosion, transform.position, transform.rotation);

        //if it has rigidbody we add a force from the grenade
        try
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        catch
        {
        }
    }
}