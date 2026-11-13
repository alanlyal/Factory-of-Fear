using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private UIManager UICanvas;
    [SerializeField] private GameObject Exit;
    private int enemiesKilled;
    public bool waveCleared = false;
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled >= enemySpawner.zombieCap)
        {
            UICanvas.ClearWave();
            waveCleared = true;
            Exit.SetActive(true);
        }
    }
}
