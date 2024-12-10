using UnityEngine;

public class BrawlerEnemy : Enemy
{
    
    // Update is called once per frame
    void Update()
    {
        CheckForEnemies();

        ApplyDamageToEnemies();
    }

}
