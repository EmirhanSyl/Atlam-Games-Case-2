using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tree : MonoBehaviour
{
    [SerializeField] private float choppingDuration;

    [SerializeField] private int treeHealth;
    [SerializeField] private int chopDamageCount = 3;

    [SerializeField] private GameObject woodPiecePrefab;

    [SerializeField] private GameObject[] bodyStates;
    [SerializeField] private Transform[] spawns;

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

        for (int i = 0; i < 4; i++)
        {
            Vector3 rot = new Vector3(0, Random.Range(0, 360), 0);

            var instantiatedLog = Instantiate(woodPiecePrefab, transform.position, Quaternion.identity);
            instantiatedLog.transform.DOMove(spawns[Random.Range(0, spawns.Length)].position, 0.6f);
            instantiatedLog.transform.DORotate(rot, 0.6f);
        }

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
