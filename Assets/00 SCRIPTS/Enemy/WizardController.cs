using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : AbstractEnemy,IDamageable
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float maxTimeShoot = 3;
    float countTime;
    [SerializeField] GameObject shooting;
    WizardAnimations wizardAnimations;
    [SerializeField] WizardState wizardState;
    [SerializeField] float distance;
    void Awake()
    {
        ActiveManager.Instant.Objects.Add(this.gameObject);
    }
    void Start()
    {
        wizardAnimations = GetComponentInChildren<WizardAnimations>();
    }
    void Update()
    {
        if (!CheckGameState())
        {
            gameObject.SetActive(false);
            return;
        }
        Fire();
    }
    void Fire()
    {
        if (transform.position.x - PlayerController.Instant.transform.position.x > distance)
            return;
        if(countTime >= 0 )
        {
            countTime -= Time.deltaTime;     
            if (wizardState != WizardState.Idle)
            {
                ChangeState(WizardState.Idle);
                UpdateAnim();
            }      
        }     
        else if (countTime < 0)
        {
            ChangeState(WizardState.Fire);
            UpdateAnim();
        }
    }
    public void ResetCountTime()
    {
        countTime = maxTimeShoot;
    }
    void ChangeState(WizardState state)
    {
        wizardState = state;
    }
    void UpdateAnim()
    {
        wizardAnimations.ChangeAnim(wizardState);
    }
    public void TakeDamage()
    {
        SetFx();
        gameObject.SetActive(false);
    }
}