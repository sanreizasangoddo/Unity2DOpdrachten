using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _jumpForce = 6f;
    private float _playerHalfHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _playerHalfHeight = _spriteRenderer.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GetIsGrounded()) {
            Jump();
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private bool GetIsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, _playerHalfHeight, LayerMask.GetMask("Ground"));
    }
}
