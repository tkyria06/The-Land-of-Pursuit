using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFire : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 100f;
    public float radius = 7f;
    public float force = 0.5f;
    private GameObject player;
    public AudioSource expSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        expSound = GameObject.Find("Audio Source(Explosion)").GetComponent<AudioSource>();
    }

    void Update()
    {
        try
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        catch
        {
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            int level = GameObject.Find("Level").GetComponent<Level>().level;
            expSound.Play(0);
            Explode();
            Vector3 contactPoint = collision.contacts[0].point;
            if (Vector3.Distance(contactPoint, player.transform.position) <= radius)
            {
                Health h = player.GetComponent<Health>();
                if (h.gettingDamage)
                    h.CurrentHealth -= (5 * level);
            }
        }
        catch
        {
        }
        
    }

    void Explode()
    {
        this.transform.GetChild(2).gameObject.SetActive(false);
        GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
        exp.transform.SetParent(this.gameObject.transform);

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
        StartCoroutine(WaitAndDestroy(0.3f));
    }

    private IEnumerator WaitAndDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }

}
