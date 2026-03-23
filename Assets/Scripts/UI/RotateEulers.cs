using UnityEngine;

public class RotateEulers : MonoBehaviour
{
    [SerializeField] Vector3 rotation;

    
    void Update()
    {
        transform.eulerAngles += rotation * Time.deltaTime;
    }
}
