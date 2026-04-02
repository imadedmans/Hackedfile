using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public enum BossPhase {Intro, Battle1, Battle2, Desperation, Death};

    [Header("Movement Variables")]
    public float moveSpeed;
    public float fasterMoveSpeed;
    public float jumpHeight;

    private bool canJump = false;
    private bool isGrounded;
    private float currentMoveSpeed;

    [Header("Timing Variables")]

    [Header("Phase 1")]
    public float P1timeBeforeMove;
    public float P1timeToMove;   
    public float P1timeBeforeShoot;
    public float P1timeBetweenEachShot;

    [Header("Phase 2")]
    public float P2timeBeforeJump;
    public float P2TimeBeforeMove;
    public float P2timeToMove;   
    public float P2timeBeforeShoot;
    public float P2timeBetweenEachShot;

    //[Header("Desperation")]


    [Header("Neccessarial Components")]
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private BossHealth bossHealth;

    [Header("Internal Objects")]
    public Transform groundCheck;
    public Transform firePoint;
    public Transform wallDetector;

    public LayerMask groundLayers;

    [Header("External Objects")]
    public GameObject player;
    public GameObject bulletObject;
    public GameObject fallingBlock; 
    public GameObject debuggableCrusher;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        bossHealth = gameObject.GetComponent<BossHealth>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //currentMoveSpeed = moveSpeed;
        currentMoveSpeed = 0f;
        StartCoroutine(BossForm(BossPhase.Battle1));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 groundColOrigin = new Vector2(transform.position.x, boxCollider2D.bounds.center.y - boxCollider2D.bounds.extents.y);
        Vector2 groundColSize = new Vector2(boxCollider2D.size.x - 0.01f, 0.01f);

        Collider2D[] groundColliders = Physics2D.OverlapBoxAll(groundColOrigin, groundColSize, groundLayers);
        foreach(Collider2D groundCollider in groundColliders)
        {
            isGrounded = true;
        }

        Vector2 wallRayDirection;
        wallRayDirection = transform.rotation.eulerAngles.y == 180 ? Vector2.right : Vector2.left;
        RaycastHit2D wallRay = Physics2D.Raycast(wallDetector.position, wallRayDirection, 1f);
        Debug.DrawRay(wallDetector.position, Vector2.left, Color.green, 1f);

         if(wallRay.collider != null)
        {
            if(wallRay.collider.tag != "Player" && wallRay.collider.tag != "Enemy")
            {
                transform.Rotate(0f, 180f, 0f);
            }
        }

        transform.Translate(Vector2.left * currentMoveSpeed * Time.deltaTime);

        if(canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Force);
            canJump = false;
        }
    }

    public IEnumerator BossForm(BossPhase phase)
    {
        switch(phase)
        {
            case BossPhase.Intro:
                //stuffs
                break; //Maybe return null?
            case BossPhase.Battle1:

                for(int i = 0; i < 4; i++)
                {
                    yield return new WaitForSeconds(P1timeBeforeMove);
                    currentMoveSpeed = moveSpeed;
                    yield return new WaitForSeconds(P1timeToMove);
                    currentMoveSpeed = 0f;
                }

                yield return new WaitForSeconds(P1timeBeforeShoot);
                // int bulletCount = Random.Range(2, 3);
                int bulletCount = 3;

                for(int i = 0; i < bulletCount; i++)
                {
                    Instantiate(bulletObject, firePoint.position, firePoint.rotation);
                    yield return new WaitForSeconds(P1timeBetweenEachShot);
                }

                StartCoroutine(BossForm(BossPhase.Battle1));
                break;

            case BossPhase.Battle2:

                yield return new WaitForSeconds(P2timeBeforeJump);
                canJump = true;

                break;
            case BossPhase.Desperation:
                //stuffs
                break;
            case BossPhase.Death:
                //stuffs
                break;
        }  
    }

    void OnDrawGizmos()
    {
        Vector2 groundColOriginRay = new Vector2(transform.position.x, boxCollider2D.bounds.center.y - boxCollider2D.bounds.extents.y);
        Vector2 groundColSizeRay = new Vector2(boxCollider2D.size.x - 0.01f, 0.01f);
        Gizmos.DrawWireCube(groundColOriginRay, new Vector3(groundColSizeRay.x, groundColSizeRay.y, 0f));
    }

    void SomeCode()
    {
        //"This is pretty much a repository for code that miiiightttt be used, however is deemed unconformed"
    }
}