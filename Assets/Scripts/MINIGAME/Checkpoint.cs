using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointManager checkMang;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        checkMang = FindObjectOfType<CheckpointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            checkMang.checkpoint = gameObject;
        }
    }
}
