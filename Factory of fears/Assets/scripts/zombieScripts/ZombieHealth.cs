using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int damage = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            maxHealth -= damage;
            Debug.Log("zombie has taken damage, hp = " + maxHealth);
            if (maxHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
