using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewDebugSystem : MonoBehaviour
{
    [System.Serializable]
    public class DebugPanel
    {
        public Dropdown[] dropdowns;
    }

    [Header("Trigger Variables")]

    public DebugPanel[] debugPanels;
    private int currentDebugIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}