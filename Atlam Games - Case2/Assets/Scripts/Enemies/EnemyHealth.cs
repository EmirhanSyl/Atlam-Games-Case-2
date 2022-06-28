using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float godModeDuration;
    [SerializeField] private float minDamageAmount;
    [SerializeField] private float maxDamageAmount;

    //[SerializeField] private ParticleSystem damageParticles;

    private float currentHealth;

    private float godModeTimer;

    private bool isDead;
    private bool godMode;

    private GameObject player;
    private Animator animator;
    private HealthBar healthBar;
    private GameManager gameManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar = GetComponentInChildren<HealthBar>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //damageParticles.gameObject.SetActive(false);

        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }


    void Update()
    {
        if (currentHealth <= 0)
        {
            Dead();
        }

        if (godMode)
        {
            godModeTimer += Time.deltaTime;
            if (godModeTimer > godModeDuration)
            {
                godModeTimer = 0;
                godMode = false;
            }
        }
    }

    public void DecreaseHealth()
    {
        if (godMode)
        {
            return;
        }

        float damage = Random.Range(minDamageAmount, maxDamageAmount);
        currentHealth -= damage;

        animator.SetTrigger("DamageTaken");

        damageParticles.gameObject.SetActive(true);
        damageParticles.Play();
        godMode = true;
    }

    void Dead()
    {
        isDead = true;
        animator.SetTrigger("Dead");
        StartCoroutine(Destroy());

        healthBar.SetHealth(currentHealth);
        IEnumerator Destroy()
        {
            yield return new WaitForSeconds(3f);

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            DecreaseHealth();
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
