using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private GameObject targetEnemy;
    private Collider[] enemyColls;

    private ArcherAttack archerAttack;

    void Start()
    {
        archerAttack = GetComponent<ArcherAttack>();
    }

    void Update()
    {
        DetectEnemy();
        if (!targetEnemy.activeSelf)
        {
            targetEnemy = null;
        }

        if (targetEnemy != null)
        {
            archerAttack.Attack(targetEnemy);
        }
    }

    void DetectEnemy()
    {
        enemyColls = Physics.OverlapSphere(transform.position, 20f, layerMask);

        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (var currentEnemyColl in enemyColls)
        {
            float distanceToCurrentEnemy = (currentEnemyColl.gameObject.transform.position - transform.position).sqrMagnitude;
            if (distanceToCurrentEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToCurrentEnemy;
                closestEnemy = currentEnemyColl.gameObject;
                targetEnemy = closestEnemy;
            }
        }
    }
}
