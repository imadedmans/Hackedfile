using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    public GameObject panel;
    private bool setPanelDeactivate = false; 

    public Text text;
    public Animator animator;

    void Awake()
    {
        text = GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(panel.activeInHierarchy == false) panel.SetActive(true);
            Cursor.visible = true;
            text.enabled = false;
            animator.enabled = false;
        }

        if(setPanelDeactivate == true) panel.SetActive(false);
    }

    public void CloseDebug()
    {
        Cursor.visible = false;
        setPanelDeactivate = true; 
    }
}
