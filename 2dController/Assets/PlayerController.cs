using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [Space]
    [SerializeField] private LayerMask groundLayerMask;

    [Header("Tile Color Settings")]
    [SerializeField] private Color accentColor = Color.red; 
    [SerializeField] private Color defaultColor = Color.white; 

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0; 
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            Move(horizontalInput * movementSpeed);
        }


        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < 1))
        {
            Jump();
        }
    }

    private void Move(float moveSpeed)
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        jumpCount++; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.LayerMaskContainsLayer(groundLayerMask, collision.gameObject.layer))
        {
            isGrounded = true;
            jumpCount = 0; 
            Debug.Log("Вы на земле");
        }

        // Handle tile color change
        TileColorChanger tileColorChanger = collision.gameObject.GetComponent<TileColorChanger>();
        if (tileColorChanger != null)
        {
            tileColorChanger.ChangeColor();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (LayerMaskUtil.LayerMaskContainsLayer(groundLayerMask, collision.gameObject.layer))
        {
            isGrounded = false;
            Debug.Log("Вы покинули землю");
        }
    }
}