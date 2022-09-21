using UnityEngine;
using Helpers;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject popUpObj;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
