using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnimations : AnimationBase<WizardState>
{
    Animator anim;
    Transform shooting;
    WizardState oldState;
    WizardController controller;
    GameObject bullet;
    void Start()
    {
        controller = GetComponentInParent<WizardController>();
        anim = GetComponent<Animator>();
        Transform parent = transform.parent;
        shooting = parent.GetComponentInChildren<Transform>().GetChild(1);
    }

    public void DoFire()
    {
        if (GameManager.Instant.GameState !=GAMESTATE.Play)
        {
            bullet.SetActive(false);
            return;
        }
        bullet = ObjectPooling.Instant.GetObject(Resources.Load("Prefabs/Fire/Fire") as GameObject, shooting.position);
        bullet.transform.position = shooting.transform.position;
        bullet.SetActive(true);
    }
    public void ResetCountTime()
    {
        controller.ResetCountTime();
    }
    public override void ChangeAnim(WizardState wizardState)
    {
        if(oldState == wizardState)
            return;
        anim.SetTrigger(wizardState.ToString());
        oldState = wizardState;
    }
}
