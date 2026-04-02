using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class JumperEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D col;
    public LayerMask enemyCollayerInt;
    bool isGrounded;
    bool canJump;
    bool canDash;

    public float jumpForce; 
    public float horizontalMove;
    public float timeInBetweenJump;
    public float timeBeforeDash;
    public float dashSpeed;

    float actHorMove;
    float actTimeBet;
    float actTimeDash;
    float randomTimer;

    Vector2 vectorRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        //StartCoroutine(JumpTest());

        actTimeBet = timeInBetweenJump;
        actTimeDash = timeBeforeDash;
    }

    public void Update()
    {
        Vector2 groundColPosition = new Vector2(col.bounds.center.x, col.bounds.center.y - col.bounds.extents.y);
        Vector2 groundColSize = new Vector2(col.bounds.size.x - 0.03f, 0.1f);
        Collider2D groundCollider = Physics2D.OverlapBox(groundColPosition, groundColSize, 0f, enemyCollayerInt);
        isGrounded = (groundCollider != null) ? true : false;

        rb.velocity = (!isGrounded && !canDash) ? new Vector2(actHorMove * Time.deltaTime, rb.velocity.y) : Vector2.zero;

        if(!isGrounded && !canDash)
        {
            actTimeBet = timeInBetweenJump;

            if(((transform.position.x <= Enemy.playerPos.x) && (actHorMove == -horizontalMove))
            ||((transform.position.x >= Enemy.playerPos.x) && (actHorMove == horizontalMove)))
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                canDash = true;
            }
        }
        else if(isGrounded)
        {
            canDash = false;
            actTimeDash = timeBeforeDash;
            vectorRotation = Vector2.zero;

            actHorMove = (Enemy.playerPos.x >= transform.position.x) ? (horizontalMove) : (-horizontalMove);
            //CodeUtilities.Timer(timeInBetweenJump, enabled);
            if(actTimeBet <= 0f)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            else
            {
                actTimeBet -= Time.deltaTime;
            }
        }

        if(canDash)
        {
            if(actTimeDash <= 0f)
            {
                if(vectorRotation == Vector2.zero)
                {
                    float distanceX = Enemy.playerPos.x - transform.position.x;
                    float distanceY = Enemy.playerPos.y - transform.position.y;
                    float angleTest = CodeUtilities.AngularAim(transform.position, false);
                    //Debug.Log("Angle: " + angleTest + " Radian: " + vectortisedY);
                    vectorRotation = new Vector2(Mathf.Cos(angleTest), Mathf.Sin(angleTest));
                }
                Debug.Log(vectorRotation);
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                transform.Translate(vectorRotation * Time.deltaTime * dashSpeed);
            }
            else
            {
                actTimeDash -= Time.deltaTime;
            }
        }

        // if(actTimeBet < timeInBetweenJump && actTimeBet > 0) 
        // {
        //     Debug.Log("Jump timer is running");
        //     randomTimer += Time.deltaTime;
        // }
        // else
        // {
        //     Debug.Log("Calculated jump time: " + randomTimer + " seconds");
        //     randomTimer = 0f;
        // }
    }

    // IEnumerator JumpTest()
    // {
    //     while(true)
    //     {
    //         bool crouIsGrounded = (isGrounded) ? true : false;
    //         if(crouIsGrounded)
    //         {
    //             yield return new WaitForSeconds(timeInBetweenJump);
    //             rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    //         }
    //     }
    // }
}
