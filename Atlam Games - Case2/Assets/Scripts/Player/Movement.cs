using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 500f;

    private Touch touch;

    private Vector3 touchDown;
    private Vector3 touchUp;

    private bool dragStarted;
    private bool isMoving;

    private AnimationManager animationManager;

    void Start()
    {
        animationManager = GetComponent<AnimationManager>();
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                dragStarted = true;
                isMoving = true;

                touchDown = touch.position;
                touchUp = touch.position;
            }
        }

        if (dragStarted)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                touchDown = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchDown = touch.position;
                isMoving = false;
                dragStarted = false;
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateTempRotation(), rotationSpeed * Time.deltaTime);
            transform.Translate(Time.deltaTime * movementSpeed * Vector3.forward);
        }

        SetMoveState();
    }

    public void SetMoveState()
    {
        if (isMoving)
        {
            animationManager.animationStatesDropdown = AnimationManager.animationStates.walk;
        }
        else
        {
            animationManager.animationStatesDropdown = AnimationManager.animationStates.idle;
        }

    }

    Quaternion CalculateTempRotation()
    {
        Vector3 tempVec = (touchDown - touchUp).normalized;
        tempVec.z = tempVec.y;
        tempVec.y = 0;

        Quaternion temp = Quaternion.LookRotation(tempVec, Vector3.up);
        return temp;
    }
}
