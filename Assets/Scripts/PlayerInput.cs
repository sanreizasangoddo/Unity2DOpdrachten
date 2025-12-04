using System.Drawing;
using Unity.Mathematics;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    /*
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    } */

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck, )
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
/*      float x = 0;
        float y = 0;
        //float z = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Ik heb LEFT ingedrukt.");
            _ = new Vector3(x = (_Xspeed), y, 0);
            transform.position -= new Vector3(x, y, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            print("Ik heb RIGHT ingedrukt.");
            _ = new Vector3(x = (_Xspeed), y, 0);
            transform.position += new Vector3(x, y, 0);
        }
         if (Input.GetKey(KeyCode.UpArrow))
        {
            print("Ik heb UP ingedrukt.");
            _ = new Vector3(x, y = (_Yspeed), 0);
            transform.position += new Vector3(x, y, 0);
        } */