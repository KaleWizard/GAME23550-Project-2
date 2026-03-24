using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent<int> OnChanged = new();
    public UnityEvent OnDeath = new();

    public int health = 1;

    [HideInInspector] public int maxHealth;

    void Start()
    {
        maxHealth = health;
    }

    public void Damage(int damage)
    {
        health -= damage;

        if (damage != 0)
            OnChanged.Invoke(health);

        if (health <= 0)
            OnDeath.Invoke();
    }
}
