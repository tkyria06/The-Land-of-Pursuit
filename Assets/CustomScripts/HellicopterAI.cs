using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HellicopterAI : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    public float targetDistance;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            PathAI();
        }
        catch
        {
            return;
        }        
    }

    private void PathAI()
    {
        Vector3 myPosition = transform.position;
        Vector3 target = player.transform.position;

        if (Vector3.Distance(myPosition, target) >= targetDistance)
        {
            agent.SetDestination(target);
        }
        

    }
}
