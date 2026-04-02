using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraAreaBox : MonoBehaviour
{
    //public bool enableLeft, enableRight, enableUp, enableDown = false;
    [Range(1, 20)] public int horExtent = 1;
    [Range(1, 20)] public int verExtent = 1;

    // private bool playOnLeft, playOnRight, playUpwards, playDownwards;
    // Vector3 leftLineOrigin, rightLineOrigin, upLineOrigin, downLineOrigin;
    // float horLineExtent, verLineExtent;
    // float horMin, horMax, verMin, verMax;
    
    float playerRangeX;
    float playerRangeY;

    Camera cameraScript;
    Transform player;
    LayerMask mask;

    Vector3 boxOrigin;
    Vector3 boxSize;
    Vector3 playerOrigin;
    bool gameStarted;
    bool playerPresent;

    void Awake()
    {
        cameraScript = FindObjectOfType<Camera>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        mask = LayerMask.GetMask("Player");
        //gameStarted = true;
    }

    void Update()
    {
        if((transform.position.x % (CameraProperties.screenX / 2)) != 0 || (transform.position.y % (CameraProperties.screenX / 2)) != 0)
        {
            float clampedX = Mathf.Round(transform.position.x / (CameraProperties.screenX / 2));
            float clampedY = Mathf.Round(transform.position.y / (CameraProperties.screenY / 2));
            transform.position = new Vector2(clampedX * (CameraProperties.screenX / 2), clampedY * (CameraProperties.screenY / 2));
        }

        playerRangeX = Mathf.Clamp(player.position.x, transform.position.x, transform.position.x + (CameraProperties.screenX * horExtent));
        playerRangeY = Mathf.Clamp(player.position.y, transform.position.y + (CameraProperties.screenX * horExtent), transform.position.y);

        Vector2 playerRangeVect = new Vector2(playerRangeX, playerRangeY);

        boxSize = new Vector3(CameraProperties.screenX * horExtent, CameraProperties.screenY * verExtent, 0f);
        boxOrigin = transform.position + new Vector3(boxSize.x / 2f, -boxSize.y / 2f, 0);

        if(Application.isPlaying)
        {
            if(playerPresent == null)
            {
                playerPresent = (player.position == playerRangeVect) ? true : false;
            }

            CheckArea();
        }
    }

    void CheckArea()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(boxOrigin, boxSize, 0f, mask);
        foreach(Collider2D collider in colliders)
        {
            Debug.Log("Hack");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(boxOrigin, boxSize);
    }

        // if(horExtent == 0 || ((verExtent > 1 || verExtent < -1) && horExtent != 0)) horExtent = 1;
        // if(verExtent == 0 || ((horExtent > 1 || horExtent < -1) && verExtent != 0)) verExtent = 1;

        // leftLineOrigin = transform.position - new Vector3((CameraProperties.screenX / 2), (CameraProperties.screenY / 2), 0);
        // rightLineOrigin = transform.position + new Vector3((CameraProperties.screenX / 2), -(CameraProperties.screenY / 2), 0);
        // upLineOrigin = transform.position + new Vector3(-(CameraProperties.screenX / 2), (CameraProperties.screenY / 2), 0);
        // downLineOrigin = transform.position - new Vector3((CameraProperties.screenX / 2), (CameraProperties.screenY / 2), 0);

        // horLineExtent = CameraProperties.screenX * horExtent;
        // verLineExtent = CameraProperties.screenY * verExtent;

        // verMin = leftLineOrigin.y;
        // verMax = transform.position.y + verLineExtent / 2;
        // horMin = downLineOrigin.x;
        // horMax = transform.position.x + horLineExtent / 2;

        // if(Application.isPlaying && gameStarted)
        // {   
        //     playerOrigin = player.position;
        //     gameStarted = false;

        //     //Debug.Log("Left: " + playOnLeft + ", Right: " + playOnRight + ", Up: " + playUpwards + ", Down: " + playDownwards);
        // }
        // else if(!Application.isPlaying && !gameStarted) gameStarted = true;
        
        // if(enableLeft) 
        // {
        //     RaycastHit2D hit = Physics2D.Raycast(leftLineOrigin, Vector3.up, verLineExtent, mask);
        //     //Debug.DrawRay(leftLineOrigin, verLineExtent * Vector3.up, Color.green);

        //     if(Application.isPlaying && (hit.collider != null))
        //     {
        //         playOnLeft = (playerOrigin.x > leftLineOrigin.x) ? true : false;
        //         Debug.Log(gameObject.name + ": Greese Monkey Left");

        //         if((player.position.x > leftLineOrigin.x) && !playOnLeft)
        //         {
        //             cameraScript.transform.position += new Vector3(CameraProperties.screenX, 0, 0);
        //             playOnLeft = true;
        //         }
        //         else if((player.position.x < leftLineOrigin.x) && playOnLeft)
        //         {
        //             cameraScript.transform.position -= new Vector3(CameraProperties.screenX, 0, 0);
        //             playOnLeft = false;
        //         }
        //     }
        // }

        // if(enableRight) 
        // {
        //     RaycastHit2D hit = Physics2D.Raycast(rightLineOrigin, Vector3.up, verLineExtent, mask);
        //     //Debug.DrawRay(rightLineOrigin, verLineExtent * Vector3.up, Color.green);

        //     if(Application.isPlaying && (hit.collider != null))
        //     {
        //         playOnRight = (playerOrigin.x < rightLineOrigin.x) ? true : false;
        //         Debug.Log(gameObject.name + "Greese Monkey Right");

        //         if((player.position.x < rightLineOrigin.x) && playOnRight)
        //         {
        //             cameraScript.transform.position += new Vector3(CameraProperties.screenX, 0, 0);
        //             playOnRight = false;
        //         }
        //         else if((player.position.x > rightLineOrigin.x) && !playOnRight)
        //         {
        //             cameraScript.transform.position -= new Vector3(CameraProperties.screenX, 0, 0);
        //             playOnRight = true;
        //         }
        //     }
        // }

        // if(enableUp) 
        // {
        //     RaycastHit2D hit = Physics2D.Raycast(upLineOrigin, Vector3.right, horLineExtent, mask);
        //     //Debug.DrawRay(upLineOrigin, horLineExtent * Vector3.right, Color.green);

        //     if(Application.isPlaying && (hit.collider != null))
        //     {
        //         playUpwards = (playerOrigin.y < upLineOrigin.y) ? true : false;
        //         Debug.Log(gameObject.name + "Greese Monkey Up");

        //         if((player.position.y < upLineOrigin.y) && !playUpwards)
        //         {
        //             cameraScript.transform.position -= new Vector3(0, CameraProperties.screenY, 0);
        //             playUpwards = true;
        //         }
        //         else if((player.position.y > upLineOrigin.y) && playUpwards)
        //         {
        //             cameraScript.transform.position += new Vector3(0, CameraProperties.screenY, 0);
        //             playUpwards = false;
        //         }
        //     }
        // }

        // if(enableDown)
        // {
        //     RaycastHit2D hit = Physics2D.Raycast(downLineOrigin, Vector3.right, horLineExtent, mask);
        //     //Debug.DrawRay(downLineOrigin, horLineExtent * Vector3.right, Color.green);

        //     if(Application.isPlaying && (hit.collider != null))
        //     {
        //         playDownwards = (playerOrigin.y > downLineOrigin.y) ? true : false;
        //         Debug.Log(gameObject.name + "Greese Monkey Down");

        //         if((player.position.y > downLineOrigin.y) && !playDownwards)
        //         {
        //             cameraScript.transform.position += new Vector3(0, CameraProperties.screenY, 0);
        //             playDownwards = true;
        //         }
        //         else if((player.position.y < downLineOrigin.y) && playDownwards)
        //         {
        //             cameraScript.transform.position -= new Vector3(0, CameraProperties.screenY, 0);
        //             playDownwards = false;
        //         }
        //     }
        // }
}
