using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNavigationSystem : MonoBehaviour
{
    public Button[] menuObjectsList;
    public Transform selectionIndicator;
    private int selectedObjectIndex = 0; 

    // Start is called before the first frame update
    void Start()
    {
        selectionIndicator.position = menuObjectsList[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {   
            selectedObjectIndex++;

            if(selectedObjectIndex >= menuObjectsList.Length)
            {
                selectedObjectIndex = 0;
            }

            selectionIndicator.position = menuObjectsList[selectedObjectIndex].transform.position;

        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {   
            if(selectedObjectIndex <= 0)
            {
                selectedObjectIndex = menuObjectsList.Length;
            }

            selectedObjectIndex--;
            selectionIndicator.position = menuObjectsList[selectedObjectIndex].transform.position;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            menuObjectsList[selectedObjectIndex].onClick.Invoke();
        }
    }
}
