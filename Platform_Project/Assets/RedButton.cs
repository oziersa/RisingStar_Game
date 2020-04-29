using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    public BlueButton blueButton;
    public PurpleButton purpleButton;
    public BoxCollider2D buttonCollider;
    private SpriteRenderer spriteRenderer;
    public Sprite upSprite;
    public Sprite downSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        buttonCollider.enabled = true;
    }

    void Update()
    {
        if (buttonCollider.enabled)
        {
            spriteRenderer.sprite = upSprite;
        }
        else
        {
            spriteRenderer.sprite = downSprite;
        }
    }

    //This button is pushed first
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            if (collision.rigidbody.velocity.y < 0.01)
            {
                Down();
            }
        }
    }

    public void Up()
    {
        buttonCollider.enabled = true;
    }

    public void Down()
    {
        buttonCollider.enabled = false;
        purpleButton.Up();
        blueButton.Up();
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
