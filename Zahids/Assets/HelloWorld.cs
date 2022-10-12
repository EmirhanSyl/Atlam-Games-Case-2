using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    int score = 2;
    //float y = 3.56456541f;

    string textYEEEEEEP = "Hello World";

    public bool isOpened = false;

    private char tek = 'd';

    public float x;
    public float y;

    float result;

    void Start()
    {
        //result = x + y;        
        result = x % 2;

        if (result == 0)
        {
            textYEEEEEEP = "Bu sayý çift";
        }
        else if(result == 1)
        {
            textYEEEEEEP = "Bu sayý tek";
        }
        else if(result == 0 || result == 1)
        {
            textYEEEEEEP = "Bu sayý tek ya da çift olamaz";
        }
        
        Debug.Log(textYEEEEEEP);

        
    }

   
    void Update()
    {
        
    }

    void Mehodddd()
    {        
       
    }
}


