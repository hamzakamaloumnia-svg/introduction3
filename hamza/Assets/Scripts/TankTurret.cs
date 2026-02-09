using UnityEngine;
using UnityEngine.InputSystem;

public class TankTurret : MonoBehaviour
{
    const string INPUT_MOUSE_POSITION = "MousePosition";
    const string INPUT_SHOOT = "Shoot";

    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private Transform _turret;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform turretCanon;

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _shootInterval=2f;
    [SerializeField] private bool isShootheld;
    private float lastShootTime = 0f;
    [SerializeField] Bullet bulletPrefab;


    private InputAction mousePositionAction;
    private InputAction shootAction;
    private Vector3 mouseDirection;

    private void Start()
    {
        mousePositionAction = inputActions.FindAction(INPUT_MOUSE_POSITION);
        shootAction = inputActions.FindAction(INPUT_SHOOT);

        shootAction.performed += Input_OnShootPressed;
        shootAction.canceled += Input_OnShootReleased;
    }

    private void OnDestroy()
    {
        shootAction.performed -= Input_OnShootPressed;
        shootAction.canceled -= Input_OnShootReleased;
    }

    private void Update()
    {
        Vector2 mousePosition = mousePositionAction.ReadValue<Vector2>();

        Ray ray = _mainCamera.ScreenPointToRay(mousePosition);

        RaycastHit info;

        Vector3 mousePositionInWorldSpace = Vector3.zero;

        if (Physics.Raycast(ray, out info, Mathf.Infinity, _layerMask))
        {
            mousePositionInWorldSpace = info.point;
        }

        mouseDirection = (mousePositionInWorldSpace - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(mouseDirection, transform.up);

        _turret.rotation = Quaternion.Slerp(_turret.rotation, lookRotation, _rotationSpeed * Time.deltaTime);

        if(isShootheld && Time.time >= lastShootTime + _shootInterval)
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        lastShootTime = Time.time;
        Debug.Log("Shoot : " + mouseDirection);
        Bullet bullet =Instantiate(bulletPrefab, turretCanon.transform.position, turretCanon.transform.rotation);
        bullet.Shoot(mouseDirection);
    }

    private void Input_OnShootPressed(InputAction.CallbackContext context)
    {
        isShootheld = true;
    }

    private void Input_OnShootReleased(InputAction.CallbackContext context)
    {
        isShootheld = false;
    }
}
