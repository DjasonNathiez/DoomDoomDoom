using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Helpers
{
    public class Interface : MonoBehaviour
    {
        /// <summary>
        /// Move an UI selected element to the destination point using Lerp move by speed
        /// </summary>
        /// <param name="element"></param>
        /// <param name="destination"></param>
        /// <param name="speed"></param>
        public static void LerpMoveTo(RectTransform element, Vector2 destination, float speed = 0f)
        {
            element.anchoredPosition = Vector2.Lerp(element.anchoredPosition, destination, speed * Time.deltaTime);
        }

        
        /// <summary>
        /// Display Pop Up at pointer position
        /// </summary>
        /// <param name="info"></param>
        /// <param name="eventData"></param>
        public static void ShowPopUp(InformationPopUp info, PointerEventData eventData)
        {
            UIManager.instance.popUpObj.SetActive(true);

            // UIManager.instance.popUpObj.GetComponent<RectTransform>().anchoredPosition =
            //     eventData.pointerEnter.GetComponent<RectTransform>().anchoredPosition * UIManager.instance.popUpPadding;
            //
            SetInformationToPopUp(info);
        }

        
        /// <summary>
        /// Set the informations of the object to the pop up UI element, hiding the UI element if there's nothing to display.
        /// </summary>
        /// <param name="info"></param>
        private static void SetInformationToPopUp(InformationPopUp info)
        {
            UIManager.instance.headerTitleTMP.text = info.headerTitle;

            UIManager.instance.headerTitleTMP.gameObject.SetActive(info.headerTitle != String.Empty);

            UIManager.instance.subTitleTMP.text = info.subTitle;

            UIManager.instance.subTitleTMP.gameObject.SetActive(info.subTitle != String.Empty);

            UIManager.instance.infoBlockTMP.text = info.infoBlock;

            UIManager.instance.infoBlockTMP.gameObject.SetActive(info.infoBlock != String.Empty);

            UIManager.instance.subInfoBlockTMP.text = info.subInfoBlock;

            UIManager.instance.subInfoBlockTMP.gameObject.SetActive(info.subInfoBlock != String.Empty);

            UIManager.instance.notesTMP.text = info.notes;

            UIManager.instance.notesTMP.gameObject.SetActive(info.notes != String.Empty);
        }

        public static void HidePopUp()
        {
            UIManager.instance.popUpObj.SetActive(false);
        }
    }

    [Serializable]
    public class InformationPopUp
    {
       [TextArea] public string headerTitle;
       [TextArea] public string subTitle;
       [TextArea] public string infoBlock;
       [TextArea] public string subInfoBlock;
       [TextArea] public string notes;
    }
}

