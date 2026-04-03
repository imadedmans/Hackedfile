using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSection : MonoBehaviour
{
    public Player player;
    public GameObject nextArea;

    public GameObject cameraObject;
    public float xPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            cameraObject.transform.position += new Vector3(xPosition, 0f, 0f);
            player.transform.position = nextArea.transform.position;
        }
    }
}
