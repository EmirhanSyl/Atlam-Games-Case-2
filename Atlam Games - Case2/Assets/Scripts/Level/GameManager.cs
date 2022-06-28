using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int woodAmount;

    void Awake()
    {
        instance = this;
    }

    
    void Update()
    {
        
    }

    public void IncreaseWood(int amount)
    {
        woodAmount += amount;
    }
}
