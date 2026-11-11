using UnityEngine;

public class ZombieSystem : MonoBehaviour
{
    [Header("Zombie settings")]
    [SerializeField] private int hp = 100;
    [SerializeField] private int shot = 10;
    [Header("Zombie points settings")]
    [SerializeField] private int perShot = 10;
    [SerializeField] private int perkill = 200;
    [Header("UI")]
    [SerializeField] private UIManager uiPoints;
    private void OnCollisionEnter(Collision bullet)
    {
        if (bullet.gameObject.CompareTag("Bullet"))
        {
            hp -= shot;
            uiPoints.givePoints(perShot);
            if (hp <= 0)
            {
                uiPoints.givePoints(perkill);
                Destroy(gameObject);
            }
        }
    }
}

