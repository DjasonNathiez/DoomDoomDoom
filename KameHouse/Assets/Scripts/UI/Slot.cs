using System;
using Helpers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

public class Slot : MonoBehaviour, IPointerClickHandler, IItemListener
{
    [SerializeField] public Item item;
    public Object obj;
    public void OnPointerClick(PointerEventData eventData)
    {
        IItemListener itemListener = GetComponent<IItemListener>();
        itemListener.GetItem(item);
    }
    
}
