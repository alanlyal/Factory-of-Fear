using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("Spawner settings")]
    [SerializeField] public int zombieCap = 24; //max number of zombies
    [SerializeField] private float minSpawnTimer = 1;
    [SerializeField] private float maxSpawnTimer = 10;
    [Header("Spawner zombiePrefab")]
    [SerializeField] private GameObject zombiePrefab;
    private Vector3 spawnerLocation;
    private float timer;
    private int spawned;

    private void Start()
    {
        spawnerLocation = transform.position;
        timer = Random.Range(minSpawnTimer, maxSpawnTimer);// so its any time from 1 to 10 seconds
    }
    private void Update()
    {
        if (spawned >= zombieCap)
        {
            return;// stops the spawning
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(zombiePrefab, spawnerLocation, Quaternion.identity); // spawns the zombie 
            timer = Random.Range(minSpawnTimer, maxSpawnTimer);// so its anytime from 1 to 10 seconds
            spawned++;
        }
    }

}
