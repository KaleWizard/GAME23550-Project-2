using UnityEngine;
using UnityEngine.InputSystem;

public class AwesomeBestCharacterController : MonoBehaviour
{
    public Vector3 direction = Vector3.zero;

    [SerializeField] float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lastPosition = transform.position;
        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += Time.deltaTime * speed * Vector3.forward;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            transform.position -= Time.deltaTime * speed * Vector3.forward;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position -= Time.deltaTime * speed * Vector3.right;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += Time.deltaTime * speed * Vector3.right;
        }
        direction = (transform.position - lastPosition).normalized;
    }
}
