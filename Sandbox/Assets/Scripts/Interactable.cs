using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    
    public Transform player;
    
    public Interactable currentInteractable = null;

    bool hasInteracted = false;



    void Update()
    {
        CheckForInteractable();
    }
    // This function checks for nearby interactable objects
    public void CheckForInteractable( )
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        
            foreach (Collider col in hitColliders)
            {
                // creates interactable when player collides with an Interactable which might be a npc or chest
                Interactable interactable = col.GetComponent<Interactable>();

                // If no collision with interactable
                if (interactable != null)
                {   
                    // Check if the player(transform) is within range of interactable object and has not interacted with anything
                    if (interactable.IsPlayerInRange(player.transform) )
                    {

                        // Take this out if you only want to interact with the object once
                        if (currentInteractable != null && currentInteractable != interactable)
                        {
                            continue;
                        }

                        currentInteractable = interactable;
                        if (currentInteractable != null)
                        {
                            if (hasInteracted == false)
                            {
                                Interact(); 

                                hasInteracted = true;
                            }
                        }
                        
                        // Take this out if you only want to interact with the object once
                        return; // Exit the function loop after finding the first interactable object
                    }
                }
            }      

        // Take this out if you only want to interact with the object once
        hasInteracted = false;


        currentInteractable = null;
    }
    
    public virtual void Interact ()
    {   
        Debug.Log("Interacting with " + gameObject.name);  
    }

    public bool IsPlayerInRange(Transform playerTransform)
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        
        return distance <= radius;

        // function checks if player.transforms distance than the transform of the objects
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;

        // this unity function allows you to place a wire sphere around an object using the position of the transform and any radius 
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
