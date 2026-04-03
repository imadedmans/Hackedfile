using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreLevelDebugScript : MonoBehaviour
{
    public Dropdown dropdown;
    //only for pre-level 3 stuff
    public GameObject passPanel;
    public GameObject errorPanel;
    private bool allowPass = false; 

    // Start is called before the first frame update
    void Start()
    {   

        if(dropdown.value == 0)
        { 
            allowPass = false;
        }

        dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
    }

    void DropdownValueChanged(Dropdown newValue)
    {
        if(dropdown.value == 0)
        {
            Debug.Log("false");
            allowPass = false;
        }
        else if(dropdown.value == 1) 
        {
            Debug.Log("true");
            allowPass = true;
        }
    }

    public void LaunchPanel()
    {
        if(allowPass == false)
        {
            errorPanel.SetActive(true);
        }
        else if(allowPass == true)
        {
            passPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
