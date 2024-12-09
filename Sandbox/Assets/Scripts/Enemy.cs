using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform player;
    public Enemy currentEnemy = null;
    public float enemyRadius = 1f;
    // Update is called once per frame
    void Update()
    {
        
    }


    void CheckForEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, enemyRadius);
        
            foreach (Collider col in hitColliders)
            {
                // creates interactable when player collides with an Interactable which might be a npc or chest
                Enemy enemy = col.GetComponent<Enemy>();

                // If no collision with interactable
                if (enemy != null)
                {   
                    // Check if the player(transform) is within range of interactable object and has not interacted with anything
                    if (enemy.IsPlayerInRange(player.transform) )
                    {
                        currentEnemy = enemy;
                        
                        return; // Exit the function loop after finding the first interactable object
                    }
                }
            }      

        // resets params to null   
        currentEnemy = null;
    }

    public bool IsPlayerInRange(Transform playerTransform)
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        
        return distance <= enemyRadius;

        // function checks if player.transforms distance than the transform of the objects
    }
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;

        // this unity function allows you to place a wire sphere around an object using the position of the transform and any radius 
        Gizmos.DrawWireSphere(transform.position, enemyRadius);
    }

}
