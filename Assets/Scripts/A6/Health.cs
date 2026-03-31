using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent<int> OnChanged = new();
    public UnityEvent OnDeath = new();

    public int health = 1;

    [SerializeField] float invulnerableTime = 0f;
    [SerializeField] bool destroyOnDeath = false;

    [HideInInspector] public int maxHealth;

    float timer = 0f;

    void Start()
    {
        maxHealth = health;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    public void Damage(int damage)
    {
        if (timer > 0f) return;

        health -= damage;

        timer = invulnerableTime;

        if (damage != 0)
            OnChanged.Invoke(health);

        if (health <= 0)
        {
            OnDeath.Invoke();
            if (destroyOnDeath)
                Destroy(gameObject);
        }
    }
}
