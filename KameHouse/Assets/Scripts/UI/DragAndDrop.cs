using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private static GameObject draggingObj;
    private Vector2 startPos;
    private bool dragging;
    private GameObject frontUISlot;

    [CanBeNull] public List<DragAndDrop> obj;

    private void Awake()
    {
       obj.AddRange(FindObjectsOfType<DragAndDrop>());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingObj = gameObject;
        startPos = transform.position;
        dragging = true;

        foreach (var dragNDrop in obj)
        {
            if (dragNDrop != this)
            {
                dragNDrop.gameObject.GetComponent<Image>().raycastTarget = false;
            }        
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        GetComponent<Image>().raycastTarget = false;
        
        foreach (var t in eventData.hovered)
        {
            if (t.CompareTag("UISlot"))
            {
                Debug.Log(t.name + " " + t.transform.childCount);
                if (t.transform.childCount == 0)
                {
                    
                    frontUISlot = t;
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingObj = null;
        GetComponent<Image>().raycastTarget = true;
        if (frontUISlot)
        {
            transform.position = frontUISlot.transform.position;
            transform.SetParent(frontUISlot.transform);
        }
        else
        {
            transform.position = startPos;
        }

        foreach (var dragNDrop in obj)
        {
            if (dragNDrop != this)
            {
                dragNDrop.gameObject.GetComponent<Image>().raycastTarget = true;
            }
        }
        
        dragging = false;
    }
}
