using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isActivate;

    public void Interact()
    {
        isActivate = true;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        
        Debug.Log("Open");
    }
}
