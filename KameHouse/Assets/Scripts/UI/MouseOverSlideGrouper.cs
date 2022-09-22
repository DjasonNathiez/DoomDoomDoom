using System;
using UnityEngine;
using Helpers;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MouseOverSlideGrouper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SlideElement[] slideElements;

    private void Start()
    {
        foreach (var slideElement in slideElements)
        {
            slideElement.hidedAnchoredPos = slideElement.obj.anchoredPosition;
        }
    }

    private void Update()
    {
        foreach (var slideElement in slideElements)
        {
            if (slideElement.pointOnIt)
            {
                if (!slideElement.isLocked)
                {
                    Interface.LerpMoveTo(slideElement.obj, slideElement.showingAnchoredPos, slideElement.slideSpeed);
                }
            }
            else
            {
                if (!slideElement.isLocked)
                {
                    Interface.LerpMoveTo(slideElement.obj, slideElement.hidedAnchoredPos, slideElement.slideSpeed);
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var slideElement in slideElements)
        {
            if (eventData.pointerEnter == slideElement.obj.gameObject)
            {
                slideElement.pointOnIt = true;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var slideElement in slideElements)
        {
            if (eventData.pointerEnter == slideElement.obj.gameObject)
            {
                slideElement.pointOnIt = false;
            }
        }
    }
}

[Serializable] public class SlideElement
{
    public RectTransform obj;
    public Vector2 hidedAnchoredPos;
    public Vector2 showingAnchoredPos;
    public float slideSpeed;
    public bool isLocked;
    public bool pointOnIt;
}
