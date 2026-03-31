using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] float seconds = 2;

    void Start()
    {
        Destroy(gameObject, seconds);
    }
}
