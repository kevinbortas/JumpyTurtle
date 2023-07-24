using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public static bool isStarted = true;

    public static float changeSpeed;
    public float moveSpeed;
    public float bounceForce = 15f;

    Rigidbody2D platform;

    void Start()
    {
        if (isStarted){
            changeSpeed = -6f;
            moveSpeed = -6f;
            isStarted = false;
        }
        platform = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveSpeed = changeSpeed;

        Vector3 movement = new Vector3(1f, 0f, 0f);

        transform.position += movement * Time.deltaTime * moveSpeed;

        if (transform.position.x < -17 || transform.position.y < -10){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().ButtonPressed("Jump");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.relativeVelocity.y <= 0f)
        {
            ScoreScript.scoreValue += 1;
            Invoke("DropPlatform", 0.02f);

            if (ScoreScript.scoreValue > 20 && ScoreScript.scoreValue <= 120){
                changeSpeed -= 0.05f;
            }
            FindObjectOfType<AudioManager>().ButtonPressed("Score");
        }
    }

    void DropPlatform()
    {
        platform.isKinematic = false;
    }
}
