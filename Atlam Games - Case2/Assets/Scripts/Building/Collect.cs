using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Log"))
        {
            other.gameObject.SetActive(false);
            gameManager.IncreaseWood(1);

            //Object pooling...
        }
    }
}
