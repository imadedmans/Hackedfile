using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Collision Variables")]
    public static bool playerIsGrounded;
    public static bool clingToWall;
    Vector2 groundColPosition;
    Vector2 groundColSize;
    Vector2 wallColPosition;
    Vector2 wallColSize;
    float walColX;
    
    [Header("Movement Variables")]
    public float runSpeed;

    public float jumpHeight;
    public float fallFloat = 2.5f;
    public float jumpRemeberanceTime;
    public float coyoteTime = 0.25f;

    public float dashingSpeed;
    public float dashingTime;
    private bool isDashing;
    bool dashChoosable = true;
    public static float actualDashTime;

    private float actualJumpRemTime;
    private float actualCoyoteTime; 
    Vector2 dashVector;

    private bool isWalled;
    public float wallSlideFloat = 4f;

    private bool canJump = false;
    private bool canDash = true;
    private bool canWall = false;

    [Header("Individual Components")]
    public BoxCollider2D col;
    public Rigidbody2D rb;
    Transform firePoint;
    //public Animator anim; (Not yet, at least for now)

    [Header("Micellanious Variables")]
    public LayerMask collisionLayerInt;
    public static bool canMove = true;
    private bool canFaceLeft;
    private float playerRbGravity;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        firePoint = GameObject.Find("Fire Point").GetComponent<Transform>();
        //anim = GetComponent<Animator>();
    }
    
    void Start()
    {
        playerRbGravity = rb.gravityScale;
        actualDashTime = dashingTime;
        actualJumpRemTime = jumpRemeberanceTime;
    }

    void Update()
    {
        playerIsGrounded = false;
        clingToWall = false;
        canWall = false;
        isWalled = false;

        //Collision
        groundColPosition = new Vector2(col.bounds.center.x, col.bounds.center.y - col.bounds.extents.y);
        groundColSize = new Vector2(col.bounds.size.x - 0.03f, 0.1f);

        Collider2D[] groundColliders = Physics2D.OverlapBoxAll(groundColPosition, groundColSize, 0f, collisionLayerInt);
        foreach(Collider2D groundCollider in groundColliders)
        {
            playerIsGrounded = true;
        }

        walColX = canFaceLeft ? (col.bounds.center.x - col.bounds.extents.x) : (col.bounds.center.x + col.bounds.extents.x);
        wallColPosition = new Vector2(walColX, col.bounds.center.y);
        wallColSize = new Vector2(0.05f, col.bounds.size.y - 0.05f);

        Collider2D[] wallColliders = Physics2D.OverlapBoxAll(wallColPosition, wallColSize, 0f, collisionLayerInt);
        foreach(Collider2D wallCollider in wallColliders)
        {
            clingToWall = true;
        }

        //Run Movement  
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        Vector2 defaultVect = new Vector2(horizontalMovement, rb.velocity.y);
 
        if(canMove && !isDashing) 
        {
            rb.velocity = defaultVect;
        }

        if(horizontalMovement > 0 && canFaceLeft && (actualDashTime < 0f) || horizontalMovement < 0 && !canFaceLeft && (actualDashTime < 0f)) Flip();

        //Jumping mechanic
        actualJumpRemTime -= Time.deltaTime;
        actualCoyoteTime = (!playerIsGrounded) ? (actualCoyoteTime -= Time.deltaTime) : coyoteTime;

        if(Input.GetButtonDown("Jump"))
        {
            actualJumpRemTime = jumpRemeberanceTime;
            canJump = true;
        }
        if(Input.GetButtonUp("Jump"))
        {
            canJump = false;
        }

        if((actualJumpRemTime > 0) && (actualCoyoteTime > 0) && canMove && !isDashing && canJump)
        {
            actualJumpRemTime = 0f;
            float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if(rb.velocity.y > 0 && !canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, Physics2D.gravity.y * (fallFloat - 1f));
            canWall = true;
        }

        if(rb.velocity.y <= 0 && !playerIsGrounded)
        {
            canWall = true;
        }

        //Wall climbing mechanic
        if(clingToWall && !playerIsGrounded && canWall && ((canFaceLeft && (Input.GetAxisRaw("Horizontal") == -1)) || (!canFaceLeft && (Input.GetAxisRaw("Horizontal") == 1))))
        {
            rb.velocity = new Vector2(rb.velocity.x, Physics2D.gravity.y * (wallSlideFloat - 1f));
            isWalled = true;
        }

        //Dashing mechanic
        actualDashTime -= Time.deltaTime;

        if(Input.GetButtonDown("Fire2") && canMove && canDash && !isDashing && !isWalled)
        {
            actualDashTime = dashingTime;
            isDashing = true;
        }

        if(isDashing)
        {
            if(actualDashTime > 0f)
            {
                if(dashVector == null || dashChoosable) 
                {
                    dashVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                    Debug.Log("Cracle");

                    if(dashVector == Vector2.zero)
                    {
                        float leftVal = (canFaceLeft) ? -1 : 1;
                        dashVector = new Vector2(leftVal, 0f);
                    }
                    
                    dashChoosable = false;
                }

                rb.velocity = new Vector2(dashVector.x, dashVector.y) * dashingSpeed;
            }

            if(actualDashTime <= 0f)
            {
                rb.gravityScale = playerRbGravity;
                rb.velocity = defaultVect;
                dashChoosable = true;
                canDash = (playerIsGrounded == true) ? true : false;

                if(canDash)
                {
                    isDashing = false;
                }
            }
            else if(actualDashTime > 0f)
            {
                rb.gravityScale = 0f;
            }
        }
    }

    void OnDrawGizmos()
    {   
        Gizmos.DrawWireCube(groundColPosition, new Vector3(groundColSize.x, groundColSize.y, 1));
        Gizmos.DrawWireCube(wallColPosition, new Vector3(wallColSize.x, wallColSize.y, 1));
    }

    private void Flip()
    {
        //Should be fixed later
        //transform.Rotate(0, 180, 0);
        firePoint.localPosition *= new Vector2(-1f, 0f);
        firePoint.Rotate(0, 180, 0);
        canFaceLeft = !canFaceLeft;
    }
}
