using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AbstractEnemy
{
    Rigidbody2D rigi;
    [SerializeField] float speedBullet;
    [SerializeField] float timeDestruct;
    void Awake()
    {
        ActiveManager.Instant.Objects.Add(this.gameObject);
    }
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        StartCoroutine(autoDestruc());
    }
    void Update()
    {
        if (!CheckGameState())
        {
            gameObject.SetActive(false);
            return;
        }
    }
    void FixedUpdate()
    {
        Moving();
    }
    protected override void Moving()
    {
        rigi.velocity = -transform.right * speedBullet;
    }
    IEnumerator autoDestruc()
    {
        yield return new WaitForSeconds(timeDestruct);

        this.gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false);

        if (collision.gameObject.GetComponent<WizardController>())
        {
            collision.gameObject.SetActive(false);
        }
    }
}
