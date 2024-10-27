using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Fell")]
    [SerializeField] private AudioClip playerFell;
    [SerializeField] public float moveForce = 5f;
    [SerializeField] public float maxSpeed = 5f;
    [SerializeField] public float jumpForce = 5f;

    private Rigidbody2D rb;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f).normalized;

        MovePlayer(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    

    void MovePlayer(Vector2 movement)
    {

        rb.AddForce(movement * moveForce);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "fallDetector")
        {
            SoundManager.instance.PlaySound(playerFell);
            transform.position = respawnPoint;
        }
    }
}
