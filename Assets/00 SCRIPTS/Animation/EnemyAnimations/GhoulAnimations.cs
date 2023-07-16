using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulAnimations : AnimationBase<GhoulState>
{
    Animator anim;
    GhoulState oldState;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public override void ChangeAnim(GhoulState ghoulState)
    {
        if (oldState == ghoulState)
            return;
        anim.SetTrigger(ghoulState.ToString());
        oldState = ghoulState;
    }
}
