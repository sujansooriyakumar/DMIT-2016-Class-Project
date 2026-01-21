using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public int maxHP;
    private int currentHP;
    public UnityEvent OnDeath;

    public void TakeDamage(int damage_)
    {
        currentHP -= damage_;
        if(currentHP <= 0)
        {
            OnDeath?.Invoke();
        }

    }

    public float GetHealthPercentage() { return currentHP / maxHP; }
}
