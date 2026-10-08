using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int scorePerEnemyDefeated = 100;

    public int CurrentScore { get; private set; } = 0;
    public UnityEvent scoreUpdated = new();
    public void OnEnemyDefeated()
    {
        CurrentScore += scorePerEnemyDefeated;
    }
}
