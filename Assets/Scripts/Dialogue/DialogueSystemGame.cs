using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueSystemGame : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public UnityEvent dialogueFinishEvent;

    public Text dialogueText;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject allowedForSkip;

    public char text { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        source.GetComponent<AudioSource>();
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && allowedForSkip.activeSelf == true)
        {
            if(index < sentences.Length - 1)
            {
                source.PlayOneShot(clip, 0.5F);
            }

            NextSentence();
        }

        if(dialogueText.text == sentences[index])
        {
            allowedForSkip.SetActive(true);
        }
    }
   
    IEnumerator Type() 
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        allowedForSkip.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            Debug.Log(index);
            dialogueText.text = "";
            StartCoroutine(Type());
        }
        else 
        {
            dialogueFinishEvent.Invoke();
        }
    }
}
