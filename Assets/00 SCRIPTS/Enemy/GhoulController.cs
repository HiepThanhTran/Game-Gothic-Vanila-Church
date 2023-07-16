using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GhoulController : AbstractEnemy,IDamageable
{
    [SerializeField] float speed;
    Rigidbody2D rigi;
    [SerializeField] GhoulState ghoulState;
    [SerializeField] bool isOnGround;
    GhoulAnimations anim; 
    void Awake()
    {
        ActiveManager.Instant.Objects.Add(this.gameObject);
    }
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<GhoulAnimations>();
    }
    void Update()
    {
        if (!CheckGameState())
        {
            gameObject.SetActive(false);
            return;
        }
        UpdateState();
        UpdateAnim();
        
    }
    void FixedUpdate()
    {
        Moving();
    }
    protected override void Moving()
    {
        if (!isOnGround)
            return;
        Vector2 movement = transform.right * speed;
        movement.y = rigi.velocity.y;
        rigi.velocity = movement;
    }
    void Flip()
    {
        Quaternion rotation = transform.rotation;
        if (rotation.y == 0)
            rotation.y = 180;
        else rotation.y = 0;
        transform.rotation = rotation;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            Flip();
        isOnGround = true;
    }

    void UpdateState()
    {
        if (!isOnGround)
            ghoulState = GhoulState.Idle;
        else ghoulState = GhoulState.Run;
    }
    void UpdateAnim()
    {
        anim.ChangeAnim(ghoulState);
    }
    public void TakeDamage()
    {
        SetFx();
        gameObject.SetActive(false);
    }
}
