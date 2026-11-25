using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 24; //how much ammo the pickup holds

    private void OnTriggerEnter(Collider other) /// player gets ammo when stepping into item, same idea as the health pickup
    {
        PlayerShooting player = other.GetComponent<PlayerShooting>();

        if (player != null)
        {
            player.AddAmmo(ammoAmount); //calls a func from playershooting script and passes ammoAmount
            Destroy(gameObject);
        }
    }
}