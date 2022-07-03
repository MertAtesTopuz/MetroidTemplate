using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private TrailRenderer traRen;

    [Header("Movement")]
    [SerializeField] private int Speed;
    private bool faceRight = true;
    public float moveInput1;

    [Header("Jumping")]
    [SerializeField] private int jumpSpeed;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float fJumpPressedRemember;
    public float fJumpPressedRememberTime;
    private float fGroundedRemember;
    public float fGroundedRememberTime;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private int extraJumps;
    public int extraJumpsValue;
    [SerializeField] Animator dustAnim;
    [SerializeField] GameObject dust;

    [Header("Dashing")]
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public bool isDashing = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        traRen = GetComponent<TrailRenderer>();
        extraJumps = extraJumpsValue;
        dashTime = startDashTime;
    }

    private void FixedUpdate()
    {
        // burası temel hareket kodu
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
        moveInput1 = Input.GetAxisRaw("Horizontal");  // horizontal inputunu sadece sağ ve sol okları kullanabilecek şekilde değiştirdim
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (faceRight == true && moveInput < 0)
        {
            Flip(); // hangi tuşa basıldığını kontrol ederek basılan tuşa göre karakterşn yönünü ayarlıyor
        }
        else if (faceRight == false && moveInput > 0)
        {
            Flip();
        }

      

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
        // dash start
        if (isDashing == true)
        {
            if (direction == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    traRen.emitting = true;
                    if (moveInput < 0)
                    {
                        direction = 1;
                    }
                    else if (moveInput > 0)
                    {
                        direction = 2;
                    }
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    traRen.emitting = false;
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;

                    if (direction == 1)
                    {
                        rb.velocity = Vector2.left * dashSpeed;
                    }
                    else if (direction == 2)
                    {
                        rb.velocity = Vector2.right * dashSpeed;
                    }
                }
            }

        }

        // dash end

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); // karakterin altında yerle etkileşimi denetlemek için bir daire oluşturuyor
        fJumpPressedRemember -= Time.deltaTime;
        fGroundedRemember -= Time.deltaTime;
        Jump();

    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void Jump()
    {
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isDJumping", false);
            extraJumps = extraJumpsValue;
            fGroundedRemember = fGroundedRememberTime;
        }

        if ((fGroundedRemember > 0) && Input.GetKeyDown(KeyCode.Z) )
        {
            fGroundedRemember = 0;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            fJumpPressedRemember = fJumpPressedRememberTime;
        }
   

        if (Input.GetKey(KeyCode.Z) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpSpeed;
                animator.SetBool("isJumping", true);
                
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        // Double Jump Start
        if (Input.GetKeyUp(KeyCode.Z))
        {
            isJumping = false;
        }
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Z) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            animator.SetBool("isDJumping", true);
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && extraJumps == 0)
        {
            fJumpPressedRemember = fJumpPressedRememberTime;
        }

        if ((fJumpPressedRemember > 0) && (fGroundedRemember > 0))
        {
            fJumpPressedRemember = 0;
            fGroundedRemember = 0;
            rb.velocity = Vector2.up * jumpSpeed;
        }
        // Double Jump End
    }

}
/*   */