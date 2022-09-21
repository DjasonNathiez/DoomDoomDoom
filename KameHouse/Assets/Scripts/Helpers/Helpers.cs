using System;
using UnityEngine;

namespace Helpers
{
    public class Interface : MonoBehaviour
    {
        public static void LerpMoveTo(RectTransform element, Vector2 destination, float speed = 0f)
        {
            element.anchoredPosition = Vector2.Lerp(element.anchoredPosition, destination, speed * Time.deltaTime);
        }

        public static void ShowPopUp()
        {
            UIManager.instance.popUpObj.SetActive(true);
        }

        public static void HidePopUp()
        {
            UIManager.instance.popUpObj.SetActive(false);
        }
    }

    [Serializable]
    public class InformationPopUp
    {
        public string headerTitle;
        public string subTitle;
        public string infoBlock;
        public string subInfoBloc;
        public string notes;
    }
}

