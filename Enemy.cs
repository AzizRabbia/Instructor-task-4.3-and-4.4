using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Target;
    Vector3 destination;
    public GameObject enemyPrefab;
    private Rigidbody enemyRb;
    private Animator enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // getting component of navmesh agent
        destination = Target.position;
        agent.SetDestination(destination); // setting destination of enemy
    
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        enemyAnim.SetBool("Is_walk", true);
        if (Vector3.Distance(destination, Target.position) > 5.0f) // enemy follow player when player moves to a specific distance
        {
            destination = Target.position;
            agent.SetDestination(destination);
        }
        


    }
}
