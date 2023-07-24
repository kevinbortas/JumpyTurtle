using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{

    public float fallMultiplier = 9f;
    public float lowJumpMultiplier = 7f;

    public float jumpVelocity = 13f;

    public Animator animator;

    Rigidbody2D rb;
    public GameObject player;

    List<Collider2D> groundTouched = new List<Collider2D>();

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player.SetActive(true);
    }

    private bool IsPointerOverUIObject() {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    void FixedUpdate()
    {
        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
        if (Input.GetMouseButtonDown(0) && groundTouched.Count != 0 && !IsPointerOverUIObject()){
            if (rb.velocity.y == 0)
            {
                rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            }
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        } else if (rb.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetBool("isJumping", false);
        ContactPoint2D[] points = new ContactPoint2D[2];
        other.GetContacts (points);
        for (int i = 0; i < points.Length; i++){
            if (points[i].normal == Vector2.up && !groundTouched.Contains(other.collider)){
                groundTouched.Add(other.collider);
                break;
            }
        }
        if (other.gameObject.name.Equals("DeathBox")){
            player.SetActive(false);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (groundTouched.Contains(other.collider)){
            groundTouched.Remove(other.collider);
        }
        if (other.gameObject.tag == "Start Platform"){
            FindObjectOfType<AudioManager>().ButtonPressed("Jump");
        }
        animator.SetBool("isJumping", true);
    }
}
