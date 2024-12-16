using UnityEngine;

public class NPC : Interactable
{


    public override void Interact()
    {
        base.Interact();
        
        Debug.Log("Interacting with " + transform.name);
    }
}
