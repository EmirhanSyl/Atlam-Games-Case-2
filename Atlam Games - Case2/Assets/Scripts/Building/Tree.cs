using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tree : MonoBehaviour
{
    [SerializeField] private float choppingDuration;

    [SerializeField] private int treeHealth;
    [SerializeField] private int chopDamageCount = 3;

    [SerializeField] private GameObject[] bodyStates;

    private float choppingTimer;

    private int activeBodyIndex = 0;
    private int chopDamage;

    private bool chopping;
    private bool hitted;

    private AnimationManager playerAnimatorManager;

    void Start()
    {
        playerAnimatorManager = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimationManager>();

        ChangeBodyState();
    }

    
    void Update()
    {
        Chopping();
    }

    void Chopping()
    {
        if (!chopping) return;
        
        choppingTimer += Time.deltaTime;
        if (choppingTimer >= choppingDuration)
        {            
            hitted = false;           
            choppingTimer = 0;
        }
        else if (choppingTimer >= choppingDuration - 0.3f && !hitted)
        {
            chopDamage++;
            if (chopDamage >= chopDamageCount)
            {
                DecreaseHealth();
                chopDamage = 0;
            }
            hitted = true;
            transform.DOShakeScale(0.8f, 0.2f);
        }
    }

    void DecreaseHealth()
    {
        treeHealth--;
        activeBodyIndex++;
        ChangeBodyState();
    }

    void ChangeBodyState()
    {
        for (int i = 0; i < bodyStates.Length; i++)
        {
            bodyStates[i].SetActive(false);
        }

        if (activeBodyIndex < bodyStates.Length)
        {
            bodyStates[activeBodyIndex].SetActive(true);
        }
        else
        {
            DestroyTree();
        }


    }

    void DestroyTree()
    {
        playerAnimatorManager.UnChop();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAnimatorManager.animationStatesDropdown = AnimationManager.animationStates.chopping;
            chopping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chopping = false;
            playerAnimatorManager.UnChop();
            choppingTimer = 0;
        }
    }
}
