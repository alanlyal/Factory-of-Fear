
using UnityEngine;

public class ZombieSystem : EnemyBase
{
    [Header("Zombie settings")]
    [SerializeField] private int shot = 10;
    private bool dead = false;
    private WaveSystem waveSystem;
    private void Awake()
    {
        UICanvas = FindAnyObjectByType<UIManager>();
        waveSystem = FindAnyObjectByType<WaveSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Take Damage
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(shot);
            if (hp <= 0 && dead == false)
            {
                dead = true;
                waveSystem.EnemyKilled();
            }

        }
    }
}

