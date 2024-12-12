using UnityEngine;

public class Enemy : Interactable
{

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
