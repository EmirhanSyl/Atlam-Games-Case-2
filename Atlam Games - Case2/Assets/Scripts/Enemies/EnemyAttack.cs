using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackDuration;
    private float attackTimer;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    public void Attack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDuration)
        {
            animator.SetTrigger("Attack");
            attackTimer = 0;

            //Damage codes...
        }
    }

    
}
