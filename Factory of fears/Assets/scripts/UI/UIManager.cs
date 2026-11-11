using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Header("UI points settings")]
    [SerializeField] private int StartingPoints = 0;
    [Header("UI elements")]
    [SerializeField] private TMP_Text pointsTxt;
    public void givePoints(int points)
    {
        points += StartingPoints;
        pointsTxt.text = "Points: " + points.ToString();
    }
}
