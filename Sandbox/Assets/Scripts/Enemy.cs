using UnityEngine;

public class Enemy : Interactable
{

    void Update()
    {
        CheckForInteractableWithInput();
    }
    public override void Interact()
    {
        base.Interact();
        // Attack enemy
    }
}
