using UnityEngine;

public class NPC : Interactable
{

    // Update is called once per frame
    void Update()
    {   
        CheckForInteractable();
    }

    public override void Interact()
    {
        base.Interact();
        // Attack enemy
    }
}
