using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [Header("UI score settings")]
     private int StartingScore = 0;
    [Header("UI elements")]
    [SerializeField] private TMP_Text pointsTxt;
    [SerializeField] private TMP_Text objectiveTxt;
    [SerializeField] private ZombieSpawner zombieSpawner;
    public void Start()
    {
        pointsTxt.text = "score: 0";
        objectiveTxt.gameObject.SetActive(false);
    }
    public void givePoints(int score)
    {
        StartingScore += score;
        pointsTxt.text = "score: " + StartingScore.ToString();
    }
    public void ClearWave()
    {
        objectiveTxt.gameObject.SetActive(true);
    }
}
