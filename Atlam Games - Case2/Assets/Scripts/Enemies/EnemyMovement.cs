using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform[] attackLocations;

    private Transform target;

    private NavMeshAgent agent;
    private EnemyAttack enemyAttack;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    
    void Update()
    {
        GoToDestination();
    }

    void GoToDestination()
    {
        if (target == null)
        {
            target = attackLocations[Random.Range(0, attackLocations.Length)];
        }

        agent.SetDestination(target.position);
        transform.DOLookAt(target.transform.position, 0.4f);

        if ((target.position - transform.position).magnitude <= 0.1f)
        {
            agent.SetDestination(transform.position);
            enemyAttack.Attack();
        }
    }
}
