using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationJump : MonoBehaviour
{

    Rigidbody2D rb;

    public Animator animator;

    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(AutoJump());
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    IEnumerator AutoJump()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 4.0f));
            Jump();
        }
    }

    void Jump()
    {
        animator.SetBool("isJumping", true);
        rb.AddForce(Vector2.up * Random.Range(12.0f, 17.0f), ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().ButtonPressed("Jump");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetBool("isJumping", false);
    }
}
