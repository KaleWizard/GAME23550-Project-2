using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerInput : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] float lerpAccel = 0.9995f;
    [SerializeField] float speed = 3f;

    CharacterController controller;

    [HideInInspector] public Vector2 input;
    Vector2 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateInput();
        Vector3 direction = new(moveDirection.x, 0f, moveDirection.y);
        Rotate(direction);
        Move(direction);
    }

    void UpdateInput()
    {
        input = Vector2.ClampMagnitude(input, 1);

        moveDirection = Vector2.Lerp(moveDirection, input, 1 - Mathf.Pow(1 - lerpAccel, Time.deltaTime));
    }

    void Rotate(Vector3 direction)
    {
        if (direction == Vector3.zero) return;
        Quaternion target = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, 1 - Mathf.Pow(1 - lerpAccel, Time.deltaTime));
    }

    void Move(Vector3 direction)
    {
        controller.Move(speed * Time.deltaTime * direction);
    }
}
