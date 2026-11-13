using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI score settings")]
    private int StartingScore = 0;
    [Header("UI elements")]
    [SerializeField] private TMP_Text pointsTxt;
    [SerializeField] private TMP_Text TaskTxt;
    [SerializeField] private TMP_Text AmmoTxt;

    private Weapon weapon;
    private void Awake()
    {
        weapon = FindAnyObjectByType<Weapon>();
    }

    public void Start()
    {
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
    public void GetAmmo(int currentAmmo, int reserves)
    {
       
        AmmoTxt.text = currentAmmo.ToString() + " | " + reserves.ToString();
    }
   
}