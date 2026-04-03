using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugSetActive : MonoBehaviour
{
    public Dropdown dropdown;
    public GameObject[] debugableWall;
    public GameObject[] enemy;

    public GlitchEffect glitchEffect;

    // Start is called before the first frame update
    void Start()
    {   
        for(int i = 0; i < enemy.Length;i++ )
        {
            enemy[i].SetActive(false);
        }

        if(dropdown.value == 0)
        {
            for(int i = 0; i < debugableWall.Length;i++ )
            {
                debugableWall[i].SetActive(true);
            }
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
            for(int i = 0; i < debugableWall.Length;i++ )
            {
                debugableWall[i].SetActive(true);
            }
        }
        else if(dropdown.value == 1) 
        {
            //add image of glitch screen here

            for(int i = 0; i < debugableWall.Length;i++ )
            {
                debugableWall[i].SetActive(false);
            }
            for(int i = 0; i < enemy.Length;i++ )
            {
                //for a certain level 3 screen
                enemy[i].SetActive(true);
            }
           
        }
    }

    public void EnemyRecieve()
    {
        Debug.Log("Finish this when you have the time");
        //Insert code where player is granted access to hack a wall
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
