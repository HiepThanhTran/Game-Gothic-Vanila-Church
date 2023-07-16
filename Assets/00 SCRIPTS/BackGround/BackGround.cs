using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    float bgLength;
    [SerializeField] Sprite bgSprite;

    float speed;
    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        bgSprite = GetComponent<SpriteRenderer>().sprite;
        bgLength = bgSprite.textureRect.width / 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instant.MoveX != 0)
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        if(Mathf.Abs(PlayerController.Instant.transform.position.x - this.transform.position.x) >= bgLength)
        {
            Vector2 pos = this.transform.position;
            pos.x = PlayerController.Instant.transform.position.x;
            this.transform.position = pos;
        }
    }
}
