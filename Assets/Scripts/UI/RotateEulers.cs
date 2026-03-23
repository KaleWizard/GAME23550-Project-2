using UnityEngine;

public class RotateEulers : MonoBehaviour
{
    public Vector3 rotation;

    
    void Update()
    {
        transform.eulerAngles += rotation * Time.deltaTime;
    }
}
