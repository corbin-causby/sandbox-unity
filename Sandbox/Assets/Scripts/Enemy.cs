using UnityEngine;
using System.Collections.Generic; // For using List<T>

public class Enemy : MonoBehaviour
{
    public Transform player;
    public List<Enemy> enemiesInRange = new List<Enemy>(); // List to hold all enemies in range
    public float enemyRadius = 1f;

    public float health = 100;

    public int damage = 10;
    public int secondaryDamage = 5;

    public KeyCode damageKey = KeyCode.Mouse0;
    public KeyCode secondaryDamageKey = KeyCode.Mouse1;

    void Update()
    {
        // Check for enemies every frame
        // CheckForEnemies();
        
        // You can add logic here to apply damage or interact with enemies in range
        // ApplyDamageToEnemies();
    }

    public void CheckForEnemies()
    {
        // Get all colliders within the radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, enemyRadius);

        // Clear the previous list of enemies in range
        enemiesInRange.Clear();

        // Loop through all the colliders that are within the radius
        foreach (Collider col in hitColliders)
        {
            // Try to get the Enemy component from the collider
            Enemy enemy = col.GetComponent<Enemy>();

            // If the object is an enemy and it is within range
            if (enemy != null && enemy.IsPlayerInRange(player))
            {
                // Add the enemy to the list
                enemiesInRange.Add(enemy);
            }
        }
    }

    public bool IsPlayerInRange(Transform playerTransform)
    {
        // Check if the player is within the radius of this enemy
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        return distance <= enemyRadius;
    }

    public void ApplyDamageToEnemies()
    {
        // Loop through all the enemies that are in range
        foreach (Enemy enemy in enemiesInRange)
        {
            // For example, apply damage to each enemy (you can replace this with your damage logic)
            // If you want the enemies to affect the player or interact with the player, do it here
            if (enemy != null)
            {
                // Apply damage to the player (example)
                // Example: enemy.TakeDamage(10);
                if (Input.GetKeyDown(damageKey))
                {
                    enemy.TakeDamage(10);
                }//else if(Input.GetKeyDown(secondaryDamageKey))
                //{
                    //enemy.TakeDamage(5);
                //}
            }
        }
    }

    // Optional: A method to handle damage to the enemy (you can customize this)
    public void TakeDamage(int _damage)
    {
        // Handle taking damage (e.g., reduce health, play a sound, etc.)
        Debug.Log(name + " took " + _damage + " damage.");
        if (enemiesInRange.Count > 1)
        {
           _damage /= enemiesInRange.Count; 
        }
        
        health -= _damage;

    }

    void OnDrawGizmosSelected()
    {
        // Visualize the radius in the editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyRadius);
    }

    
}
