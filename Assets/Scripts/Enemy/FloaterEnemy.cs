using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterEnemy : MonoBehaviour
{
    public float frequency;
    public float amplitude;

    Vector2 offsetPos = new Vector2();
    Vector2 tempPos = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        offsetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Code the make it float(not part of the main code)
        tempPos = offsetPos;
        tempPos.y += Mathf.Sin(Time.deltaTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }
}
