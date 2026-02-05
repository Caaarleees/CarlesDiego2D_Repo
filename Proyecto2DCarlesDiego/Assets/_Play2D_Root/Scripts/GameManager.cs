using UnityEngine;
using TMPro; // Solo si usas TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText; // Arrastra aquí tu UI Text

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddPoint(int amount = 1)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}