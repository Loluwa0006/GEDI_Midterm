using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    [SerializeField] int scorePerEnemyDefeated = 100;
    [SerializeField] TMP_Text scoreTracker;

    public int CurrentScore { get; private set; } = 0;



    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    public void OnEnemyDefeated()
    {
        CurrentScore += scorePerEnemyDefeated;
        scoreTracker.text = CurrentScore.ToString();
    }
}
