using UnityEngine;

public class Levier : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        IInteractable door = FindObjectOfType<Door>().GetComponent<IInteractable>();

        if (door != null)
        {
            door.Interact();
        }

    }
}
