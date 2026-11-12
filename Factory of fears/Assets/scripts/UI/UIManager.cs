using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI score settings")]
    private int StartingScore = 0;
    [Header("UI elements")]
    [SerializeField] private TMP_Text pointsTxt;
    [SerializeField] private TMP_Text TaskTxt;
  
    public void Start()
    {
        pointsTxt.text = "score: 0";
        TaskTxt.gameObject.SetActive(false);
    }
    public void givePoints(int score)
    {
        StartingScore += score;
        pointsTxt.text = "score: " + StartingScore.ToString();
    }
    public void ClearWave()
    {
        TaskTxt.gameObject.SetActive(true);
    }
}