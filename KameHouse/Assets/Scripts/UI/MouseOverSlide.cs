using UnityEngine;
using UnityEngine.EventSystems;
using Helpers;

public class MouseOverSlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform linkedObject;
    private Vector2 hidedAnchoredPos;
    public Vector2 showingAnchoredPos;
    public float moveSpeed;
    private bool isLocked;
    private bool pointOnIt;

    private void Awake()
    {
        hidedAnchoredPos = linkedObject.anchoredPosition;

    }

    private void Update()
    {
        if (pointOnIt)
        {
            if (!isLocked)
            {
                Interface.LerpMoveTo(linkedObject, showingAnchoredPos, moveSpeed);
            }
        }
        else
        {
            if (!isLocked)
            {
                Interface.LerpMoveTo(linkedObject, hidedAnchoredPos, moveSpeed);
            }
        }
        
    }

    public void IsLocked(bool value)
    {
        isLocked = value;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        pointOnIt = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointOnIt = false;
    }
}
