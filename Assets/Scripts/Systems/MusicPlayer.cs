using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip stageMusic;
    public float sgMusLoopStart;
    public float sgMusLoopEnd;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        audioSource.clip = stageMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.time >= sgMusLoopEnd)
        {
            audioSource.time = sgMusLoopStart;
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            audioSource.volume = (audioSource.volume > 0) ? 0f : 1f;
        }
    }
}
