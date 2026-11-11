using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Header("UI score settings")]
     private int StartingScore = 0;
    [Header("UI elements")]
    [SerializeField] private TMP_Text pointsTxt;
    public void Start()
    {
        pointsTxt.text = "score: 0";
    }
    public void givePoints(int score)
    {
        StartingScore += score;
        pointsTxt.text = "score: " + StartingScore.ToString();
    }
}
