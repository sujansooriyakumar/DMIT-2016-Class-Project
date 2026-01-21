using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float atk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;
        collision.gameObject.GetComponent<PlayerStats>().TakeDamage((int)atk);
    }
}
