using UnityEngine;

public class ExitScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private WaveSystem waveSystem;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Awake()
    {
        waveSystem = FindAnyObjectByType<WaveSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (waveSystem.waveCleared == true)
            {
                gameObject.SetActive(true);
                Application.Quit(); // for now
            }
           
        }
    }
}
