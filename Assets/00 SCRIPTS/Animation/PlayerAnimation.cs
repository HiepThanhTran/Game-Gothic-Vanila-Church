using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAnimation : AnimationBase<PlayerState>
{
    Animator animator;
    PlayerState oldState;
    PlayerController playerController;

    public Animator Animator { get => animator; set => animator = value; }

    static readonly int attackState = Animator.StringToHash("AttackState");

    //AttackState
    const float noneAttackState = 0f;
    const float kickAttackState = 1.2f;
    const float punchAttackState = 2.2f;

    //AirState
    const float jumpState = 0f;
    const float fallState = 1f;
    const float flyingKickState = 2f;

    //ShitDownState
    const float crouchState = 0f;
    const float crouchAttackState = 0.5f;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Jump();
        Crouch();
        Attack();
    }
    void Crouch()
    {
        if (Input.GetKey(KeyCode.C) || playerController.PlayerState != PlayerState.Crouch)
            return;

        animator.SetFloat(attackState, crouchState);
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.C))
            return;
        if (playerController.PlayerState == PlayerState.Jump)
            animator.SetFloat(attackState, jumpState);
        else if (playerController.PlayerState == PlayerState.Fall)
            animator.SetFloat(attackState, fallState);
    }
    void Attack()
    {
        if (playerController == null)
            return;

        if (Input.GetKey(KeyCode.C))
        {
            if (playerController.PlayerState == PlayerState.Fall || playerController.PlayerState == PlayerState.Jump)
            {
                animator.SetFloat(attackState, flyingKickState);
            }
        }
        if (playerController.PlayerState == PlayerState.Idle || playerController.PlayerState == PlayerState.Walk)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                playerController.AttackState = AttackState.Kick;
                animator.SetFloat(attackState, kickAttackState);
            }
        }
        else if (playerController.PlayerState == PlayerState.Crouch && Input.GetKeyDown(KeyCode.C))
        {
            animator.SetFloat(attackState, crouchAttackState);
        }
    }
    public void DoAttack()
    {
        playerController.AttackEnemy();
    }
    public void FinishCombo()
    {
        if (Input.GetKey(KeyCode.C) && playerController.AttackState == AttackState.Kick)
        {
            playerController.AttackState = AttackState.Punch;
            animator.SetFloat(attackState, punchAttackState);
            return;
        }
        animator.SetFloat(attackState, noneAttackState);
        playerController.AttackState = AttackState.None;
        playerController.PlayerState = PlayerState.Idle;
    }
    public override void ChangeAnim(PlayerState playerState)
    {
        if(playerState != PlayerState.Fall)
            animator.SetTrigger(playerState.ToString());
        if ((playerState == PlayerState.Idle && oldState == PlayerState.Fall) || oldState == PlayerState.Jump || oldState == PlayerState.Hurt)
        {
            animator.SetFloat(attackState, noneAttackState);
            playerController.AttackState = AttackState.None;
        }
        oldState = playerState;
    }
}
