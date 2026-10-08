using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyEntity : BaseEntity
{
    public void OnBubbleHit()
    {
        stateMachine.TransitionTo("EnemyBubble");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerEntity playerEntity))
        {
            //weak to player touch and die
            if (stateMachine.CurrentState.GetType() == typeof(EnemyBubbleState))
            {
                ScoreManager.instance.OnEnemyDefeated();
                Destroy(gameObject);
            }
            else
            { 
                //Die and reload
                SceneManager.LoadScene("SampleScene");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bubble"))
        {
            stateMachine.TransitionTo("EnemyBubble");
        }
    }
}
