using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float damageCooldown = 1f;

    private float lastDamaged;

    private void OnTriggerStay(Collider other)
    {
        EnemyBase enemy = other.GetComponentInParent<EnemyBase>();

        if (enemy != null && Time.time >= lastDamaged + damageCooldown)
        {
            player.TakeDamage(enemy.GetDamage());
            lastDamaged = Time.time;
        }
    }
}