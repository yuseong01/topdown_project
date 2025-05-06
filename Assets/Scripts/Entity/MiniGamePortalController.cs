using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{
    private bool hasEntered = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if(hasEntered) return;

        if(collision.gameObject.CompareTag("Player"))
        {
            Vector3 playerPos = collision.transform.position;
            Vector3 portalPos = transform.position;

            if(playerPos.x<portalPos.x)
            {
                Debug.Log("왼쪽에서 닿음!!");
                spriteRenderer.flipX = true;
                hasEntered=true;
                SceneManager.LoadScene("FlappyPlane");
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}
