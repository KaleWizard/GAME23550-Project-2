using UnityEngine;

public class DamageSphere : MonoBehaviour
{
    [SerializeField] bool damageOnStart = false;

    [SerializeField] LayerMask layers;
    [SerializeField] float radius;

    void Start()
    {
        if (damageOnStart) Damage();
    }

    public void Damage()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layers, QueryTriggerInteraction.Collide);

        foreach (var collider in hits)
        {
            Debug.Log(collider.gameObject.name);
            if ((layers.value >> collider.gameObject.layer) % 2 != 0 && collider.TryGetComponent<Health>(out var health))
            {
                health.Damage(1);
            }
        }
    }
}
