using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = System.Object;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Item item;

    private void Awake()
    {
        if (item.GetType() == typeof(IGearItem))
        {
            IGearItem gear = (IGearItem)item;
            gear.Equip();
        }

        if (item.GetType() == typeof(IConsommableItem))
        {
            IConsommableItem conso = (IConsommableItem)item;
            conso.Consume();
        }

        if (item.GetType() == typeof(IQuestItem))
        {
            IQuestItem quest = (IQuestItem)item;
            Debug.Log("c'est une quête");

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerPress.GetComponent<Slot>().item.GetType());

        switch (item.GetType())
        {
            case IGearItem:

                IGearItem gear = (IGearItem)eventData.pointerPress.GetComponent<Slot>().item;
                
                gear.Equip();
                break;
            
            case IConsommableItem:

                break;
            
            case IQuestItem:

                break;
        }
    }
}
