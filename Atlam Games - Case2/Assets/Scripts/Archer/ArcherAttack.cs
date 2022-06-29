using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArcherAttack : MonoBehaviour
{
    [SerializeField] private float attackDuration;
    [SerializeField] private float attackOfsetDuration;

    [SerializeField] private Transform bowInitLocation;
    [SerializeField] private GameObject arrowPrefab;

    private float attackTimer;
    private float attackOffsetTimer;

    private bool throwed;

    private GameObject target;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack(GameObject _target)
    {
        target = _target;
        attackTimer += Time.deltaTime;

        transform.DOLookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), 0.4f);
        if (attackTimer >= attackDuration)
        {
            animator.SetTrigger("Attack");            
            attackTimer = 0;
            throwed = true;
        }

        if (throwed)
        {
            attackOffsetTimer += Time.deltaTime;
            if (attackOffsetTimer >= attackOfsetDuration)
            {
                ThrowArrow();
                attackOffsetTimer = 0;
                throwed = false;
            }
        }
    }

    void ThrowArrow()
    {
        var arrow = Instantiate(arrowPrefab, bowInitLocation.position, Quaternion.identity);
        arrow.GetComponent<ArrowMovement>().ChargeToEnemy(target.transform);
    }
}
