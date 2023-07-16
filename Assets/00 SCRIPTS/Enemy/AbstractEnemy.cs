using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    [SerializeField] protected float damage;
    protected virtual bool CheckGameState()
    {
        return GameManager.Instant.GameState == GAMESTATE.Play;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ColliderPlayer"))
        {
            collision.gameObject.GetComponentInParent<PlayerController>().TakeDamage(damage);
        }
    }
    protected virtual void SetFx()
    {
        GameObject fx = ObjectPooling.Instant.GetObject(Resources.Load("Prefabs/FX/FXDeath") as GameObject);
        fx.transform.position = this.transform.position;
        fx.SetActive(true);
    }
    protected virtual void Moving() { }
}
