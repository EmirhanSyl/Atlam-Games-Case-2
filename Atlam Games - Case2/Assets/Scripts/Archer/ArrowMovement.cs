using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject collesionFX;

    private float deactivationTimer;
    private bool charge;

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
        transform.LookAt(targetTransform.position);
        charge = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            other.gameObject.GetComponent<EnemyHealth>().DecreaseHealth();

            deactivationTimer = 0;
            gameObject.SetActive(false);
        }
        else if (other.gameObject.layer == 7) //7 = Wall layer
        {
            deactivationTimer = 0;

            Instantiate(collesionFX, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    private void DeactivationTimer()
    {
        deactivationTimer += Time.deltaTime;
        if (deactivationTimer > 6)
        {
            deactivationTimer = 0;
            gameObject.SetActive(false);
        }
    }
}
