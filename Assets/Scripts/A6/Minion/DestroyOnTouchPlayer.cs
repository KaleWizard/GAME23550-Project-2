using UnityEngine;

public class DestroyOnTouchPlayer : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if ((playerLayer.value >> other.gameObject.layer) % 2 != 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
