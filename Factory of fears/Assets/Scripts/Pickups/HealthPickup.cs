using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healAmount = 20; //amount thats transferred into Heal method

    private void OnTriggerEnter(Collider other) /// player is healed when stepping into item - this can be turned into a button press later (ie. press e to pickup health kit)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            Debug.Log("Healed 25");

            player.Heal(healAmount); //calls heal from playercontroller script and passes healamount
            Destroy(gameObject); //one time use
        }
    }
}
