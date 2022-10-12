using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Color newColor;
    Rigidbody2D rig;
    SpriteRenderer dsf�ljsdg�lkds�l;

    bool isMoving;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        dsf�ljsdg�lkds�l = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (rig.velocity == Vector2.zero)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        if (isMoving)
        {
            dsf�ljsdg�lkds�l.color = Color.red;
        }
        else
        {
            dsf�ljsdg�lkds�l.color = Color.yellow;
        }
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * 5);
        
    }
}
