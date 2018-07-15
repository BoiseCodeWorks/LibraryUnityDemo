using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent), typeof(Rigidbody))]
public class AIMotor : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    Rigidbody rb;
    EnemyManager boss;
    bool attacking;
    public float AttackCoolDown = 2;
    public GameObject Target;
    public float MaxSpeed = 3;

    // Use this for initialization
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        boss = FindObjectOfType<EnemyManager>();
        Target = boss.GetTarget();
        /**
         * What we want to do next
         * we need a reference to the candy
         * tell the agent what the candy postion is
         * go get it
         */

    }

    IEnumerator StartAttack()
    {
        agent.speed = 0;
        anim.SetTrigger("StartAttack");
        attacking = true;
        yield return new WaitForSeconds(AttackCoolDown);
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking) { return; } //stop all other action

        if(Target != null) // If the candy is real 
        {
            var distanceToTarget = Vector3.Distance(Target.transform.position, agent.transform.position);
            if(distanceToTarget > agent.stoppingDistance)
            {
                //GO GET THE CANDY
                agent.speed = MaxSpeed;
                agent.SetDestination(Target.transform.position);
            }else
            {
                StartCoroutine(StartAttack());
            }            
            anim.SetFloat("Speed", agent.speed);
        }else
        {
            var nextTarget = boss.GetTarget();
            if (nextTarget)
            {
                Target = nextTarget;
            }
        }
    }
}
