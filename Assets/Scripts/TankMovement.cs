using UnityEngine;
using UnityEngine.InputSystem;

public class ControllablePlayer : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    private InputAction moveAction;
    const string INPUT_MOVE = "Move";
    [SerializeField] private float _speed = 5f;
    private Vector3 velocity;
    [SerializeField] private float _turnSpeed = 5f;
    private float _bodyRotation = 0f;

    private void Start()
    {
        moveAction = actions.FindAction(INPUT_MOVE);
    }
    private void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        if(input.y != 0f)
        {
        _bodyRotation += input.x * _turnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(_bodyRotation, transform.up);
        } 
        // velocity = new Vector3(input.x, 0, input.y) * _speed;
        //transform.position += velocity * Time.deltaTime;
        transform.position += transform.forward * _speed * Time.deltaTime * input.y;


    }


}
