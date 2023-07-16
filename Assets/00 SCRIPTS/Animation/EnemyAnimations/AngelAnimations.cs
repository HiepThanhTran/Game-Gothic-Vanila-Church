using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelAnimations : AnimationBase<AngleState>
{ 
    Animator animator;
    AngleState oldState;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void ChangeAnim(AngleState angleState)
    {
        if(angleState == oldState)
            return;
        animator.SetTrigger(angleState.ToString());
        oldState = angleState;
    }
}
