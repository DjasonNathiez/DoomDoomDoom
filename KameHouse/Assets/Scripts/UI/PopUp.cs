using UnityEngine;
using Helpers;
using UnityEngine.EventSystems;

public class PopUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InformationPopUp informationPopUp;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Interface.ShowPopUp(informationPopUp, eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Interface.HidePopUp();
    }
}
