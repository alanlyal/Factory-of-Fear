using UnityEngine;

public class ExitScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private WaveSystem waveSystem;
   
    private void Awake()
    {
        waveSystem = FindAnyObjectByType<WaveSystem>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (waveSystem.waveCleared == true)
            { 
                Application.Quit(); // for now
                Debug.Log("game closed");
            }
           
        }
    }
}
