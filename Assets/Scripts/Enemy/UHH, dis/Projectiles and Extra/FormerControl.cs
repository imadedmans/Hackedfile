using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormerControl : MonoBehaviour
{
    SpriteRenderer sr;
    BoxCollider2D bc;

    public float posDifference;
    public float timeBeforeInitiate;
    public float timeBetweenEnable;

    public GameObject formObject1;
    public GameObject formObject2;
    public GameObject formObject3;

    public float timeBeforeFollow;
    public float followSpeed;

    GameObject[] formerParts = new GameObject[3];
    public enum partPos {Up, Down, Left, Right};
    partPos[] partsDirection;
    bool canFollow = false;

    //void OnValidate()

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();

        sr.enabled = false;
        bc.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        formerParts[0] = formObject1;
        formerParts[1] = formObject2;
        formerParts[2] = formObject3;

        for(int i = 0; i < formerParts.Length; i++)
        {
            //formerParts[i].transform.position = new Vector2(-10, posDifference * (i - 1));
            FormerPart partScript = formerParts[i].GetComponent<FormerPart>();
            partScript.targetPos = new Vector2(transform.position.x, posDifference * (i - 1));
            formerParts[i].SetActive(false);
        }

        // partsDirection[0] = projectileDirection1;
        // partsDirection[1] = projectileDirection2;
        // partsDirection[2] = projectileDirection3;
        // for(int i = 0; i < partsDirection.Length; i++)
        // {
        //     GameObject curPart = Instantiate(formObj, transform.position, Quaternion.identity);
        //     switch(partPos)
        //     {
        //         case partPos.Up:
        //             break;
        //         case partPos.Down:
        //             break;
        //         case partPos.Left:
        //             break;
        //         case partPos.Right:
        //             break;
        //     }
        // }

        StartCoroutine(BattlePhase());
    }

    // Update is called once per frame
    void Update()
    {
        if(formerParts[formerParts.Length - 1].transform.position.x == transform.position.x)
        {
           for(int i = 0; i < formerParts.Length; i++)
            {
                formerParts[i].SetActive(false);
            }

            sr.enabled = true;
            bc.enabled = true;
            canFollow = true;
        }

        if(canFollow)
        {
            float distanceX = Enemy.playerPos.x - transform.position.x;
            float distanceY = Enemy.playerPos.y - transform.position.y;
            float angleTest = Mathf.Atan2(distanceY, distanceX);
            Vector2 vectorRotation = new Vector2(Mathf.Cos(angleTest), Mathf.Sin(angleTest));
            transform.Translate(vectorRotation * followSpeed * Time.deltaTime);
        }
    }

    IEnumerator BattlePhase()
    {        
        yield return new WaitForSeconds(timeBeforeInitiate);
        for(int i = 0; i < formerParts.Length; i++)
        {
            formerParts[i].SetActive(true);
            yield return new WaitForSeconds(timeBetweenEnable);
        }
    }
}
