using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour
{
    public static BaseBuilding Instance;

    [SerializeField] private float maxHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private HealthBar generalHealthBar;

    private float currentHealth;

    void Start()
    {
        Instance = this;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        generalHealthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
        healthBar.SetHealth(currentHealth);
        generalHealthBar.SetHealth(currentHealth);
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
