using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public new Camera camera;

    public Transform obj1;
    public Transform obj2;

    float camMinHor;
    float camMaxHor;

    float playerPosX;
    float playerPosY;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        camera = FindObjectOfType<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Min: " + camMinHor + "Max: " + camMaxHor);
    }

    // Update is called once per frame
    void Update()
    {
        camMinHor = obj1.position.x + (CameraProperties.screenX / 2);
        camMaxHor = obj2.position.x - (CameraProperties.screenX / 2);
        Debug.Log("Min: " + camMinHor + "Max: " + camMaxHor);

        playerPosX = player.transform.position.x;
        playerPosY = player.transform.position.y;

        if(playerPosX >= camMinHor && playerPosX <= camMaxHor)
        {
            Debug.Log("DSLKAJDKLSAJDSALJD hey.");
            camera.transform.position = new Vector3(playerPosX, camera.transform.position.y, camera.transform.position.z);
        }
    }
}
