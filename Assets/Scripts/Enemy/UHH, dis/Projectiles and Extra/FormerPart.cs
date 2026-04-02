using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormerPart : MonoBehaviour
{
    public float timeBeforeMove;
    float actBefTime;

    [HideInInspector] public Vector2 targetPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actBefTime += Time.deltaTime;
        if(actBefTime >= timeBeforeMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
