using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Helpers;

public class MouseOverSlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform linkedObject;
    public List<GameObject> graphicTarget;
    public Vector2 hidedAnchoredPos;
    public Vector2 showingAnchoredPos;
    public float moveSpeed;
    public bool isLocked;
    public bool pointOnIt;

    private void Awake()
    {
        hidedAnchoredPos = linkedObject.anchoredPosition;

        for (int i = 0; i < linkedObject.childCount; i++)
        {
            graphicTarget.Add(linkedObject.GetChild(i).gameObject);
        }
        
        graphicTarget.Add(linkedObject.gameObject);
        graphicTarget.Add(gameObject);

        linkedObject.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (pointOnIt)
        {
            if (!isLocked)
            {
                linkedObject.gameObject.SetActive(true);
            
                Interface.LerpMoveTo(linkedObject, showingAnchoredPos, moveSpeed);
            }
        }
        else
        {
            if (!isLocked)
            {
                Interface.LerpMoveTo(linkedObject, hidedAnchoredPos, moveSpeed);
            
                linkedObject.gameObject.SetActive(false);
            }
        }
        
        
      
    }

    public void IsLocked(bool value)
    {
        isLocked = value;
        Debug.Log("Locked");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter zone");
        foreach (GameObject obj in graphicTarget)
        {
            if (eventData.pointerEnter == obj)
            {
                pointOnIt = true;
            }
        }
       
        
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit zone");
        pointOnIt = false;
        
    }
}
