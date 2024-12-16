using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int maxHealth = 100;
    public int CurrentHealth {get; private set;}

    public KeyCode interactKey;
    public Stat damage;

    void Awake ()
    {
        CurrentHealth = maxHealth;
    }

    void Update ()
    {   
        //if (Input.GetKeyDown(interactKey))
        //{
            //TakeDamage(10);
        //}
    }

    public void TakeDamage (int damage)
    {

        // Make sure damage never goes below 0
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if  (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die ()
    {
        // Die in some way
        // This method is meant to be overwritten

        Debug.Log(transform.name + " died.");
    }
}

