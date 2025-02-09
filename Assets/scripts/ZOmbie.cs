using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZOmbie : MonoBehaviour
{
    public Transform target;
    public float runDistance = 5;
    public float runSpeed = 5;
    public float walkSpeed = 1;

    private NavMeshAgent agent;
    private Animator Animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        agent.speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        var dinstance = Vector3.Distance(transform.position, target.position);
       if (dinstance >= runDistance)
        {
            agent.speed = runSpeed;
        }
        else agent.speed = walkSpeed; 
        Animator.SetBool("isRunning",dinstance >= runDistance);
            if (target != null) { 
          agent.SetDestination(target.position);

            }
    }
}
