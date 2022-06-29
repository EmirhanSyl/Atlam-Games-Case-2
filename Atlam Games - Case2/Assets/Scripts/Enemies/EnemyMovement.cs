using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    private GameObject[] attackLocations;
    private Transform target;

    private NavMeshAgent agent;
    private EnemyAttack enemyAttack;
    private EnemyHealth enemyHealth;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyAttack = GetComponent<EnemyAttack>();
        enemyHealth = GetComponent<EnemyHealth>();

        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }

        attackLocations = GameObject.FindGameObjectsWithTag("MonsterTarget");
    }

    
    void Update()
    {
        if (enemyHealth.IsDead())
        {
            StartCoroutine(WaitForDie());
            return;
        }
        GoToDestination();
    }

    void GoToDestination()
    {
        if (target == null)
        {
            target = attackLocations[Random.Range(0, attackLocations.Length)].transform;
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

    IEnumerator WaitForDie()
    {
        yield return new WaitForSeconds(0.6f);
        agent.SetDestination(transform.position);
    }
}
