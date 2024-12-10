using UnityEngine;

public class BrawlerEnemy : Enemy
{

    public int brawlerDamage = 10;
    
    public override void ApplyDamageToEnemies()
    {
        base.ApplyDamageToEnemies();
        // Additional logic for brawler can be added here
    }

    public override void TakeDamage(int _damage)
    {

        base.TakeDamage(brawlerDamage);
        // Brawlers may have unique damage handling logic
    }

}
