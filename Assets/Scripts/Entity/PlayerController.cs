using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    protected AnimationHandler animationHandler;
    private SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        animationHandler = GetComponent<AnimationHandler>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveX, moveY).normalized;
        if(moveX<0) 
            spriteRenderer.flipX=true;
        else if(moveX>0)
            spriteRenderer.flipX=false;
            
        rb.velocity = move * speed;

        animationHandler.Move(move);

    }
}
