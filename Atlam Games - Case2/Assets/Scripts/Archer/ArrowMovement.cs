using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private float deactivationTimer;
    private bool charge;

    private Transform target;

    void Update()
    {
        if (charge)
        {
            transform.Translate(Time.deltaTime * movementSpeed * Vector3.forward);
            DeactivationTimer();
        }
    }

    public void ChargeToEnemy(Transform targetTransform)
    {
        target = targetTransform;

        transform.LookAt(targetTransform.position + new Vector3(0, 0.3f, 0));
        charge = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            other.gameObject.GetComponent<EnemyHealth>().DecreaseHealth();

            deactivationTimer = 0;
            ArrowPooler.instance.AddPool(gameObject);
            gameObject.SetActive(false);
        }
        else if (other.gameObject.layer == 7) //7 = Wall layer
        {
            deactivationTimer = 0;            
            ArrowPooler.instance.AddPool(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void DeactivationTimer()
    {
        deactivationTimer += Time.deltaTime;
        if (deactivationTimer > 6)
        {
            deactivationTimer = 0;
            ArrowPooler.instance.AddPool(gameObject);
            gameObject.SetActive(false);
        }
    }
}
