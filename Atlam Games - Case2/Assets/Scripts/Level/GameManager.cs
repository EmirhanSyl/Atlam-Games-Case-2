using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TMP_Text woodCountText;
    [SerializeField] private TMP_Text raidTimeText;
    [SerializeField] private TMP_Text raidCountText;

    private int woodAmount;

    void Awake()
    {
        instance = this;
    }

    
    void Update()
    {
        woodCountText.text = woodAmount.ToString();
    }

    public void RaidText(int remainTime)
    {
        int min = 0;
        int sec = 0;

        while (remainTime >= 60)
        {
            remainTime -= 60;
            min++;
        }
        sec = remainTime % 60;
        if (sec < 10)
        {
            raidTimeText.text = min.ToString() + ":0" + sec.ToString();
        }
        else
        {
            raidTimeText.text = min.ToString() + ":" + sec.ToString();
        }        
    }
    public void RaidCountText(string text)
    {
        raidCountText.text = "Wave - "+ text;
    }

    public void IncreaseWood(int amount)
    {
        woodAmount += amount;
    }
    
    public void DecreaseWood(int amount)
    {
        woodAmount -= amount;
    }

    public int WoodCount()
    {
        return woodAmount;
    }

    public void GameOver()
    {

    }
}
