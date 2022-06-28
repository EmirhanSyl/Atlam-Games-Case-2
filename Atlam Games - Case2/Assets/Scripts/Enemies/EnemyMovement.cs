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

        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
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
        

        if ((target.position - transform.position).magnitude <= 0.2f)
        {
            agent.SetDestination(transform.position);
            enemyAttack.Attack();
            animator.SetBool("IsMoving", false);
        }
        else
        {
            agent.SetDestination(target.position);
            transform.DOLookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), 0.4f);

            animator.SetBool("IsMoving", true);
        }
    }
}
