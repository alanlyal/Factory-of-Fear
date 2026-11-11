using UnityEngine;

public class ZombieSystem : MonoBehaviour
{
    [Header("Zombie settings")]
    [SerializeField] private int hp = 100;
    [SerializeField] private int shot = 10;
    [Header("Zombie score settings")]
    [SerializeField] private int perShot = 10;
    [SerializeField] private int perkill = 200;
    [Header("UI")]
    [SerializeField] private UIManager UICanvas;
    private void OnCollisionEnter(Collision bullet)
    {
        if (bullet.gameObject.CompareTag("Bullet"))
        {
            hp -= shot;
            UICanvas.givePoints(perShot);

            if (hp <= 0)
            {
                UICanvas.givePoints(perkill);
                Destroy(gameObject);
            }
        }
    }
}

