using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float dashForce = 3;
    [SerializeField] float dashDuration = 3;
    [SerializeField] Transform feetBottom;
    [SerializeField] ForceMode2D forceMode;
    [SerializeField] LayerMask layerMask;
    [SerializeField] TrailRenderer trailRenderer;
    Rigidbody2D rb;
    bool canJump;
    bool isFliped;
    bool isMoving;
    bool isDashing;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFliped = false;
        isMoving = false;
    }
    void Update()
    {
        Move(Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.F)) StartCoroutine(dashRoutine());
    }
    public void Move(float direction)
    {
        if (isDashing) return;
        if(direction > 0 && isFliped || direction < 0 && !isFliped)
        {
            Flip();
        }
        if((direction > 0 || direction < 0) && !isMoving || Mathf.Approximately(0, direction) && isMoving)
        {
            isMoving = !isMoving;
            animator.SetBool("IsMoving", isMoving);
        }
        rb.velocity = new Vector3(direction * speed, rb.velocity.y, 0);
    }
    void Flip()
    {
        isFliped = !isFliped;
        int rotY = isFliped ? 180 : 0;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotY, transform.eulerAngles.z);
    }
    public void Jump()
    {
        if (!canJump) return;
        rb.AddForce(Vector2.up * jumpForce, forceMode);
        animator.SetBool("Jump", true);
        canJump = false;
    }
    public void Dash()
    {
        int dir = isFliped ? -1 : 1;
        rb.AddForce(dashForce * dir * Vector2.right, ForceMode2D.Impulse);
    }
    IEnumerator dashRoutine()
    {
        trailRenderer.emitting = true;
        isDashing = true;
        float grav = rb.gravityScale;
        rb.gravityScale = 0;
        int dir = isFliped ? -1 : 1;
        rb.velocity = new Vector3(dir * dashForce, 0, 0);
        yield return new WaitForSeconds(dashDuration);
        rb.velocity =  Vector3.zero;
        rb.gravityScale = grav;
        isDashing = false;
        trailRenderer.emitting = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Physics2D.Raycast(feetBottom.position, Vector2.down, 0.1f, layerMask))
        {
            animator.SetBool("Jump", false);
            canJump = true;
        }
    }
}
