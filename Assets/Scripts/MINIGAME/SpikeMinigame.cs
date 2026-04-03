using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMinigame : MonoBehaviour
{
    public CheckpointManager checkMana;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D checkpoint)
    {
        if (checkpoint.name == "Player")
        {
            checkMana.CheckpointAccess();
        }
    }
}
