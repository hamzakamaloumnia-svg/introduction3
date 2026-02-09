/*using UnityEngine;
using UnityEngine.InputSystem;

public class ControllablePlayer : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    private InputAction moveAction;
    const string INPUT_MOVE = "Move";
    [SerializeField] private float _speed = 5f;
    private Vector3 velocity;

    private void Start()
    {
        moveAction = actions.FindAction(INPUT_MOVE);
    }
    private void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y) * _speed;
        transform.position += velocity * Time.deltaTime;
   
    }


}*/
