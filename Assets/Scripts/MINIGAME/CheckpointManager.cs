using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Player player;
    public GameObject checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMINIGAMEFIEWKJGFIEUFGWUY()
    {
        Time.timeScale = 1.0f;
    }

    public void CheckpointAccess()
    {
        player.transform.position = checkpoint.transform.position;
    }
}
