using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 1f;
    public float jumpForce = 1f;
    public float maxSpeed = 10f;
    private Vector2 moveVector;
    public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerInputHandler inputHandler = GetComponent<PlayerInputHandler>();
        inputHandler.OnJumpInputRecieved += Jump;
        inputHandler.OnMoveInputRecieved += Move;
    }
    public void Move(float moveDirection_)
    {
        moveVector.x = moveDirection_ * moveSpeed;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForceY(jumpForce);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {

        if(isGrounded) rb.linearVelocity = new Vector2(moveVector.x, rb.linearVelocity.y);
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Ground") == false) return;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f);

        if (!hit) return;
        if (hit.collider.gameObject.tag != "Ground" && hit.collider.gameObject != this.gameObject) return;

        isGrounded = true;
    }


}
