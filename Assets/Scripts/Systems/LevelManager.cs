using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject deathScreen; 
    public GameObject introPanel;
    public GameObject spawnPosition;

    Transform spanPosTrans;
    MusicPlayer musicPlayer;
    SpriteRenderer playerSprite;
    Rigidbody2D playerRigid;
    Animator introAnim;
    bool introIsActive = true; 
    public bool canIntro = false;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerSprite = player.GetComponent<SpriteRenderer>();
        playerRigid = player.GetComponent<Rigidbody2D>();
        introAnim = introPanel.GetComponent<Animator>();
        
        spanPosTrans = spawnPosition.transform;
        musicPlayer = GameObject.FindWithTag("Music").GetComponent<MusicPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        introPanel.SetActive(false);
        deathScreen.SetActive(false);
        introAnim.enabled = false;
        musicPlayer.enabled = false;

        if(canIntro)
        {
            introPanel.SetActive(true);

            Behaviour[] playerComponents = player.GetComponents<Behaviour>();
            foreach(Behaviour component in playerComponents)
            {
                component.enabled = false;
            }
        
            StartCoroutine(IntroSequence());
        }
        else
        {
            introPanel.SetActive(false);
            musicPlayer.enabled = true;
        }
    }
    

    IEnumerator IntroSequence()
    {
        player.transform.position = new Vector2(spanPosTrans.position.x, spanPosTrans.position.y);
        playerRigid.constraints = RigidbodyConstraints2D.FreezePosition;
        playerSprite.enabled = false;

        yield return new WaitForSeconds(0.5f);

        for(int i = 0; i < 4; i++)
        {
            playerSprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
            playerSprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
        }

        playerSprite.enabled = true;

        introAnim.enabled = true;
        AnimatorClipInfo[] animClipInfo = introAnim.GetCurrentAnimatorClipInfo(0);
        float animationTiming = animClipInfo[0].clip.length;
        yield return new WaitForSeconds(animationTiming);

        Behaviour[] playerComponents = player.GetComponents<Behaviour>();
        foreach(Behaviour component in playerComponents)
        {
            component.enabled = true;
        }

        playerRigid.constraints = RigidbodyConstraints2D.None;
        playerRigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        musicPlayer.enabled = true;
        introIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.activeInHierarchy == false && !introIsActive)
        {
            deathScreen.SetActive(true);
            musicPlayer.enabled = false;
        }
    }
}
