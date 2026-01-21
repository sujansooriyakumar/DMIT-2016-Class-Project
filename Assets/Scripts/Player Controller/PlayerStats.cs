using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public int maxHP;
    private int currentHP;
    public int coins;
    public UnityEvent OnDeath;
    public UnityEvent OnCoinCollect;

    public void TakeDamage(int damage_)
    {
        currentHP -= damage_;
        if(currentHP <= 0)
        {
            OnDeath?.Invoke();
        }

    }

    public float GetHealthPercentage() { return currentHP / maxHP; }
    public void CollectCoin()
    {
        coins++;
        OnCoinCollect?.Invoke();
    }
}
