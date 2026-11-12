
using UnityEngine;

//ALL ENEMIES INHERIT ENEMYBASE
//HEALTH AND DAMAGE SETTINGS CHANGED IN EDITOR
public class EnemyBase : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] protected int hp = 100;
    [SerializeField] protected int damage = 10;

    [Header("Score Settings")]
    [SerializeField] protected int perShot = 10;
    [SerializeField] protected int perKill = 200;

    [Header("UI")]
    [SerializeField] protected UIManager UICanvas;

    public int GetDamage()
    {
        return damage;
    }

    public virtual void TakeDamage(int amount)
    {
        hp -= amount;
        UICanvas.givePoints(perShot);

        if (hp <= 0)
        {
            UICanvas.givePoints(perKill);
            Destroy(gameObject);
        }
    }
}