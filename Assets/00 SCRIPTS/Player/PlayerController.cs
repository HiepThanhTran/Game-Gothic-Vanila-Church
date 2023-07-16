using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Singleton<PlayerController>
{
    public float MoveX { get => moveX; set => moveX = value; }
    public float Speed { get => speed; set => speed = value; }
    public Transform AttackPoint { get => attackPoint; set => attackPoint = value; }
    public PlayerState PlayerState { get => playerState; set => playerState = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public float DamageCoolDown { get => damageCoolDown; set => damageCoolDown = value; }
    public float HurtDuration { get => hurtDuration; set => hurtDuration = value; }
    public AttackState AttackState { get => attackState; set => attackState = value; }

    float moveX;

    Rigidbody2D rigi;

    float speed, jumpForce;

    bool canBeDamaged = true; // Xác định xem Player có thể bị đụng hay không

    float damageCoolDown; // Thời gian cooldown giữa các lần bị đụng 

    float currentCooldown; // Thời gian còn lại cho cooldown

    Animator animator;
    [SerializeField] bool isOnGround;

    [SerializeField] PlayerState playerState;

    [SerializeField] AttackState attackState;

    PlayerAnimation playerAnimation;

    [SerializeField] Transform attackPoint;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip hurtSound, attackSound, jumpSound, killSound;

    [SerializeField] GameObject pointWin;

    float hurtDuration;
    float currentHurtTime;
    void Awake()
    {
        ActiveManager.Instant.Objects.Add(this.gameObject);
    }
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponentInChildren<PlayerAnimation>();
        audioSource = GetComponentInChildren<AudioSource>();
    }
    void Update()
    {
        if (GameManager.Instant.GameState != GAMESTATE.Play)
        {
            gameObject.SetActive(false);
            return;
        }
        Jumping();
        UpdateState();
        UpdateAnim();
        TimeChangeHurt();
        TimeAttack();
    }
    void FixedUpdate()
    {
        if (playerState == PlayerState.Hurt)
            return;
        Moving();
        Flip();
    }
    void Moving()
    {
        moveX = speed * Input.GetAxisRaw("Horizontal");
        rigi.velocity = new Vector2(moveX, rigi.velocity.y);
    }
    void Flip()
    {
        if (moveX > 0)
            transform.localScale = Vector3.one;
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    void Jumping()
    {
        if (playerState == PlayerState.Hurt)
            return;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rigi.AddForce(new Vector2(0, jumpForce));
            playerState = PlayerState.Jump;
            audioSource.PlayOneShot(jumpSound);
        }
        else if (rigi.velocity.y < 0 && !isOnGround)
            playerState = PlayerState.Fall; 
    }
    void UpdateState()
    {
        if (!isOnGround)
            return;

        if (currentHurtTime > 0)
        {
            playerState = PlayerState.Hurt;
            currentHurtTime -= Time.deltaTime;
            return;
        }
        if (Input.GetKey(KeyCode.DownArrow) && (playerState != PlayerState.Fall || playerState != PlayerState.Jump))
            playerState = PlayerState.Crouch;
        else if (moveX != 0)
            playerState = PlayerState.Walk;
        else playerState = PlayerState.Idle;

    }
    public void AttackEnemy()
    {
        audioSource.PlayOneShot(attackSound);
        RaycastHit2D[] hits = Physics2D.BoxCastAll(attackPoint.position, new Vector2(2, 2), 0, Vector2.zero);
        foreach (var hit in hits)
        {
            if (hit.transform.gameObject.TryGetComponent<IDamageable>(out IDamageable dame))
            {
                dame.TakeDamage();
            }
        }
    }
    void UpdateAnim()
    {
        playerAnimation.ChangeAnim(playerState);
    }
    public void TakeDamage(float dmg)
    {
        if (!canBeDamaged)
            return;

        if (PlayerHP.Instant.CurrentHp > 0)
        {
            PlayerHP.Instant.CurrentHp -= dmg;
            if (PlayerHP.Instant.CurrentHp <= 0)
            {
                Died();
                return;
            }
            audioSource.PlayOneShot(hurtSound);
            currentHurtTime = hurtDuration;
        }
        canBeDamaged = false;
        currentCooldown = damageCoolDown;
    }
    void Died()
    {
        if (PlayerHP.Instant.CurrentHp > 0)
            PlayerHP.Instant.CurrentHp = 0;
        audioSource.PlayOneShot(killSound);
        StartCoroutine(WaitTimeEnd());
    }
    IEnumerator WaitTimeEnd()
    {
        yield return new WaitForSeconds(0.01f);
        GameManager.Instant.GameState = GAMESTATE.Over;
    }
    void TimeAttack()
    {
        if (canBeDamaged)
            return;
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0)
        {
            canBeDamaged = true;
        }
    }
    void TimeChangeHurt()
    {
        if (currentHurtTime > 0)
        {
            currentHurtTime -= Time.deltaTime;
            if (currentHurtTime <= 0)
            {
                return;
            }
        }
    }
    void WinGame()
    {
        GameManager.Instant.GameState = GAMESTATE.Win;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lose"))
            Died();
        else if (collision.gameObject.CompareTag("Win"))
            WinGame();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}