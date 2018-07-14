using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMotor : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Target;
    public float Speed = 3;

    // Use this for initialization
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        /**
         * What we want to do next
         * we need a reference to the candy
         * tell the agent what the candy postion is
         * go get it
         */

    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = Speed;
        if(Target != null) // If the candy is real 
        {
            //GO GET THE CANDY
            agent.SetDestination(Target.transform.position);
        }
    }
}
