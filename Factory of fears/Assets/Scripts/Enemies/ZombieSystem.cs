using UnityEngine;

public class ZombieSystem : EnemyBase
{
    [Header("Zombie settings")]
    [SerializeField] private int shot = 10;
    private bool dead = false;
    [SerializeField] private EnemySpawner enemySpawner;
    private void OnCollisionEnter(Collision collision)
    {
        //Take Damage
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(shot);
            if (hp <= 0 && dead == false)
            {
                dead = true;
                enemySpawner.zombieKilled++;
                UICanvas.givePoints(perKill);
                Destroy(gameObject);
                if (enemySpawner.zombieKilled == enemySpawner.zombieCap)
                {
                    UICanvas.ClearWave();
                }
            }

        }
    }
}

