using UnityEngine;

public class BrawlerEnemy : Interactable
{

    public float enemyHealth = 100;

    bool isDead = false;


    // Update is called once per frame
    void Update()
    {
        CheckForInteractable();

        if(currentInteractable != null)
        {
            HitEnemy();

            if(isDead == true)
            {
                KillEnemy();
                currentInteractable = null;
            }
        }
    }

    void HitEnemy()
    {

        if(Input.GetKeyDown(interactKey) && isDead == false)
        {
            if (enemyHealth > 0)
            {
                enemyHealth -= 10;  
            }
            else 
            {
                isDead = true;
            }
            
        }
        
    }

    void KillEnemy()
    {
        Destroy(this.gameObject);
    }
}
