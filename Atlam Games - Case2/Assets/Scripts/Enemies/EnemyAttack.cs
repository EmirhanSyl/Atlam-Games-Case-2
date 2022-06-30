using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackDuration;

    [SerializeField] private float minAttackDamage;
    [SerializeField] private float maxAttackDamage;

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
        transform.LookAt(BaseBuilding.Instance.gameObject.transform.position);       

        if (attackTimer >= attackDuration)
        {
            BaseBuilding.Instance.DecreaseHealth(Random.Range(minAttackDamage, maxAttackDamage));

            animator.SetTrigger("Attack");
            attackTimer = 0;
        }
    }

    
}
