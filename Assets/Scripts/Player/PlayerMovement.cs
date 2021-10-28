using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private GameObject[] hearts;
    private int actualHeath = 3;
    private bool canJump = false;
    private float x;
    private bool isFacingRight = true;

    public bool wantFacingRight => rb.velocity.x >= 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        Flip();
        if (Input.GetButtonDown("Jump")) canJump = true;

    }

    private void TakeDamage()
    {
        if (actualHeath == 0) return;
        Destroy(hearts[actualHeath - 1]);
        actualHeath--;
        if (actualHeath == 0)
        {
            animatorPlayer.SetInteger("health", actualHeath);
        }
    }

    private void Flip()
    {
        if (wantFacingRight != isFacingRight)
        {
            Debug.Log("want" + wantFacingRight + "is" + isFacingRight);
            var lc = transform.localScale;
            isFacingRight = !isFacingRight;
            lc.x *= -1;
            transform.localScale = lc;
        }
    }

    void FixedUpdate()
    {
        Move(x);
        if (canJump)
        {
            Jump();
            canJump = false;
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }

    private void Move(float x)
    {
        rb.velocity = new Vector2(x * speed * Time.fixedDeltaTime, rb.velocity.y);
        animatorPlayer.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }
}