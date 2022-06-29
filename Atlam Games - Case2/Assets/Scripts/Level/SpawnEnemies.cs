using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private RaidUnits raid;

    [SerializeField] private float raidDuration;

    [SerializeField] private GameObject brownSpiderPrefab;
    [SerializeField] private GameObject greenSpiderPrefab;
    [SerializeField] private GameObject greySpiderPrefab;

    [SerializeField] private GameObject zombieLegPrefab;
    [SerializeField] private GameObject zombieLegMetalicPrefab;

    private float raidTimer;

    private int raidCount;

    private GameObject[] topSpawns;
    private GameObject[] downSpawns;
    private GameObject[] rightSpawns;
    private GameObject[] leftSpawns;


    void Start()
    {
        topSpawns = GameObject.FindGameObjectsWithTag("TopSpawn");
        downSpawns = GameObject.FindGameObjectsWithTag("DownSpawns");
        rightSpawns = GameObject.FindGameObjectsWithTag("RightSpawns");
        leftSpawns = GameObject.FindGameObjectsWithTag("LeftSpawns");
    }

    
    void Update()
    {
        raidTimer += Time.deltaTime;
        if (raidTimer >= raidDuration)
        {
            RaidIsComing();
            raidTimer = 0;
        }
    }

    void RaidIsComing()
    {

    }
}
