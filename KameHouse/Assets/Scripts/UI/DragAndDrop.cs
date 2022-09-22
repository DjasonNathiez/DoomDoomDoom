using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public static GameObject draggingObj;
    public Vector2 startPos;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingObj = gameObject;
        startPos = transform.position;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingObj = null;
        //transform.position = startPos;
    }
}
