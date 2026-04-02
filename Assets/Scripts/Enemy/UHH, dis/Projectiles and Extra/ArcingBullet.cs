using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcingBullet : MonoBehaviour
{
    Vector3 startPos;
    Vector3 targetPos;
    public float speed = 5f;
    public float arcHeight = 1f;
    public bool aimedAtPlayer = false;
    float nextFloat;
    Vector2 next;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Vector3 nonPlayPosThing = transform.position + new Vector3(20f, 0f, 0f);
        Vector3 otherPlayPosThing = new Vector3(Enemy.playerPos.x, Enemy.playerPos.y, 0f);
        targetPos = aimedAtPlayer ? otherPlayPosThing : nonPlayPosThing;
        nextFloat = CodeUtilities.AngularAim(transform.position, false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = targetPos.x - startPos.x;
        // float nextX = Mathf.MoveTowards(transform.position.x, targetPos.x, speed * Time.deltaTime);
        // float nextY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - startPos.x) / distance);
        Vector2 next = new Vector2(Mathf.Cos(nextFloat), Mathf.Sin(nextFloat)) * speed * Time.deltaTime;
        float arc = arcHeight * (transform.position.x - startPos.x) * (transform.position.x - targetPos.x) / (-0.25f * distance * distance);
        transform.position += new Vector3(next.x, next.y, 0);
    }
}
