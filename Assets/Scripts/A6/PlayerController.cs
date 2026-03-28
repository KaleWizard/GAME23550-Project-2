using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] float lerpAccel = 0.8f;
    [SerializeField] float speed = 2f;

    CharacterController controller;

    Vector2 lastInput = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 input = GetInput();
        Vector3 direction = new(input.x, 0f, input.y);
        Rotate(direction);
        Move(direction);
    }

    Vector2 GetInput()
    {
        Vector2 input = Vector2.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            input += Vector2.up; // Up
        }
        if (Keyboard.current.sKey.isPressed)
        {
            input -= Vector2.up; // Down
        }
        if (Keyboard.current.aKey.isPressed)
        {
            input -= Vector2.right; // Left
        }
        if (Keyboard.current.dKey.isPressed)
        {
            input += Vector2.right; // Right
        }
        input = Vector2.ClampMagnitude(input, 1);

        return lastInput = Vector2.Lerp(lastInput, input, lerpAccel);
    }

    void Rotate(Vector3 direction)
    {
        if (direction == Vector3.zero) return;
        Quaternion target = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, lerpAccel);
    }
    
    void Move(Vector3 direction)
    {
        controller.Move(speed * Time.deltaTime * direction);
    }
}
