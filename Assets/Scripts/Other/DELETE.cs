using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DELETE : MonoBehaviour
{
    public GameObject panel;
    public GlitchEffect glitchEffect;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        GameObject g = GameObject.Find("Main Camera");
        GlitchEffect glitchEffect = g.GetComponent<GlitchEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            Time.timeScale = 0.0f;
            UI();
        }

    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void UI()
    {
        glitchEffect.enabled = false;
        panel.SetActive(true);
    }
}
