using TMPro;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    [Header("Spawner settings")]
    [SerializeField] public int zombieCap = 24; //max number of zombies
    [SerializeField] private float MinspawnTimer = 1;
    [SerializeField] private float MaxspawnTimer = 10;
    [SerializeField] public  int zombieKilled =0; // the amount of zombies needed to be killed to end the wave
    [Header("Spawner zombiePrefab")]
    [SerializeField] private GameObject zombiePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
