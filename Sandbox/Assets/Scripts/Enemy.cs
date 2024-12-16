using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{

    PlayerManager playerManager;
    CharacterStats myStats;

    Interactable interactable;

    void Start ()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();

        // Attack enemy
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }
}
