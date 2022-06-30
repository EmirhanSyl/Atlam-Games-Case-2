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

    private int raidCount = 1;

    private GameObject[] topSpawns;
    private GameObject[] downSpawns;
    private GameObject[] rightSpawns;
    private GameObject[] leftSpawns;


    void Start()
    {
        topSpawns = GameObject.FindGameObjectsWithTag("TopSpawn");
        downSpawns = GameObject.FindGameObjectsWithTag("DownSpawn");
        rightSpawns = GameObject.FindGameObjectsWithTag("RightSpawn");
        leftSpawns = GameObject.FindGameObjectsWithTag("LeftSpawn");

        GameManager.instance.RaidCountText(raidCount.ToString());
    }

    
    void Update()
    {
        raidTimer += Time.deltaTime;
        if (raidTimer >= raidDuration)
        {
            RaidIsComing();
            raidTimer = 0;
        }

        GameManager.instance.RaidText((int)(raidDuration - raidTimer));
    }

    void RaidIsComing()
    {
        var raidWay = ChooseRaidWay();   


        switch (raidCount)
        {            
            case 1:
                raidCount++;
                GameManager.instance.RaidCountText(raidCount.ToString());

                for (int i = 0; i < raid.brownSpiderCount_Raid1; i++)
                {
                    Instantiate(brownSpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.greenSpiderCount_Raid1; i++)
                {
                    Instantiate(greenSpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.greySpiderCount_Raid1; i++)
                {
                    Instantiate(greySpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.zombieLegCount_Raid1; i++)
                {
                    Instantiate(zombieLegPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.zombieLegMetalicCount_Raid1; i++)
                {
                    Instantiate(zombieLegMetalicPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                break;

            case 2:
                for (int i = 0; i < raid.brownSpiderCount_Raid2; i++)
                {
                    Instantiate(brownSpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.greenSpiderCount_Raid2; i++)
                {
                    Instantiate(greenSpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.greySpiderCount_Raid2; i++)
                {
                    Instantiate(greySpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.zombieLegCount_Raid2; i++)
                {
                    Instantiate(zombieLegPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.zombieLegMetalicCount_Raid2; i++)
                {
                    Instantiate(zombieLegMetalicPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                break;

            case 3:
                for (int i = 0; i < raid.brownSpiderCount_Raid3; i++)
                {
                    Instantiate(brownSpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.greenSpiderCount_Raid3; i++)
                {
                    Instantiate(greenSpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.greySpiderCount_Raid3; i++)
                {
                    Instantiate(greySpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.zombieLegCount_Raid3; i++)
                {
                    Instantiate(zombieLegPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.zombieLegMetalicCount_Raid3; i++)
                {
                    Instantiate(zombieLegMetalicPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                break;

            case 4:
                for (int i = 0; i < raid.brownSpiderCount_Raid4; i++)
                {
                    Instantiate(brownSpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.greenSpiderCount_Raid4; i++)
                {
                    Instantiate(greenSpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.greySpiderCount_Raid4; i++)
                {
                    Instantiate(greySpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.zombieLegCount_Raid4; i++)
                {
                    Instantiate(zombieLegPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.zombieLegMetalicCount_Raid4; i++)
                {
                    Instantiate(zombieLegMetalicPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                break;

            case 5:
                for (int i = 0; i < raid.brownSpiderCount_Raid5; i++)
                {
                    Instantiate(brownSpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.greenSpiderCount_Raid5; i++)
                {
                    Instantiate(greenSpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.greySpiderCount_Raid5; i++)
                {
                    Instantiate(greySpiderPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.zombieLegCount_Raid5; i++)
                {
                    Instantiate(zombieLegPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                for (int i = 0; i < raid.zombieLegMetalicCount_Raid5; i++)
                {
                    Instantiate(zombieLegMetalicPrefab, raidWay[Random.Range(0, raidWay.Length)].transform.position, Quaternion.identity);
                }
                break;
        }
    }

    GameObject[] ChooseRaidWay()
    {
        int raidWay = Random.Range(0, 4);
        GameObject[] spawnWay = topSpawns;

        switch (raidWay)
        {
            case 0:
                spawnWay = topSpawns;
                break;
            case 1:
                spawnWay = downSpawns;
                break;
            case 2:
                spawnWay = rightSpawns;
                break;
            case 3:
                spawnWay = leftSpawns;
                break;
        }
        return spawnWay;
    }
}
