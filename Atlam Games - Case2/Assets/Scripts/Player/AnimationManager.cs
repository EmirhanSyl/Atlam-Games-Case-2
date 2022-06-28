using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public enum animationStates { idle, walk, chopping };
    public animationStates animationStatesDropdown;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        SetAnimationStates();
    }

    void SetAnimationStates()
    {
        switch (animationStatesDropdown)
        {
            case animationStates.idle:
                animator.SetBool("IsMoving", false);
                break;
            case animationStates.walk:
                animator.SetBool("IsMoving", true);
                break;
            case animationStates.chopping:
                animator.SetBool("Chop", true);
                break;
        }
    }

    public void UnChop()
    {
        animator.SetBool("Chop", false);
    }
}
