using UnityEngine;

public class ZombieSystem : EnemyBase
{
    [Header("Zombie settings")]
    [SerializeField] private int shot = 10;


    private void OnCollisionEnter(Collision collision)
    {
        //Take Damage
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(shot);
        }
    }
}

