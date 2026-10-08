using UnityEngine;

public class BubbleProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyEntity enemy))
        {
            enemy.OnBubbleHit();
        }
    }
}
