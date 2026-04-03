using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTrigger : MonoBehaviour
{
    private GameObject camera;
    public GameObject oldPanel; 
    public GameObject oldAlert;
    public GameObject alertMessage; 

    public AudioClip triggerSoundFX;
    private AudioSource aS;
    private SpriteRenderer sR;
    private BoxCollider2D bC;
    public bool ensurity = true;
    public bool enabledByEnemy = false; 
    public float timeCanLinger = 10f;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindWithTag("Camera");
        //flashEffect = GameObject.Find("FlashEffect");

        if(!enabledByEnemy)
        {
            sR = GetComponent<SpriteRenderer>();
            bC = GetComponent<BoxCollider2D>();
        }

        aS = GetComponent<AudioSource>();
        alertMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            AudioPlayAndGameObjectDelete();
        }
    }

    public void AudioPlayAndGameObjectDelete()
    {
        if(ensurity)
        {
            oldPanel.SetActive(false);
            oldAlert.SetActive(false);
        }

        alertMessage.SetActive(true);


        // Animator flashEffectAnimRun = flashEffect.GetComponent<Animator>();
        // flashEffectAnimRun.enabled = true;
        // flashEffectAnimRun.SetBool("canFlash", true);

        if(!enabledByEnemy)
        {
            sR.enabled = false; 
            bC.enabled = false; 
        }
    
        aS.PlayOneShot(triggerSoundFX, 0.3F);

        StartCoroutine(CountBeforeDestroy());
    }

    IEnumerator CountBeforeDestroy()
    {
        yield return new WaitForSeconds(timeCanLinger);
        Destroy(gameObject);
    }
}
