using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToDamage : MonoBehaviour
{
    [SerializeField] Health health;
    
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            health.Damage(1);
        else if (Mouse.current.rightButton.wasPressedThisFrame)
            health.Damage(-1);
    }
}
