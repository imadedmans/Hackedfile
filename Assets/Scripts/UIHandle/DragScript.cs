using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragScript : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform drag;
    [SerializeField] private Canvas canvas; 

    public void OnDrag(PointerEventData eventData)
    {
        drag.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }
}
