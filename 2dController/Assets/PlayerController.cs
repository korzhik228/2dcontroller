using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [Space]
    [SerializeField] private LayerMask groundLayerMask;

    private Rigidbody2D rb;
    private bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // if (TryGetComponent(out Rigidbody2D rb))
        // { 
        //    this.rb = rb;
        // }

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            Move(horizontalInput * movementSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }
    private void Move(float moveSpeed)
    {

        //rb.velocity
        rb.AddForce(new Vector2(moveSpeed, 0));

    }
    private void Jump() =>
        rb.AddForce(new Vector2(0, jumpForce),
            ForceMode2D.Impulse);
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.LayerMaskContainsLayer(groundLayerMask,
            collision.gameObject.layer))
        {
            Debug.Log("ûûûûû");
        }
    }
}
