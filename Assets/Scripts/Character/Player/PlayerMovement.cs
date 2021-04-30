using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    

    private Rigidbody2D _rigibody;
    private Camera _camera;
    private Transform _transform; 

    private Vector2 _direct;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _camera = Camera.main;
    }

    private void Start()
    {
        InputController.Instance.Input.Player.Movement.performed += SetDirection;

        InputController.Instance.Input.Player.Movement.canceled += StopMovement;
    }

    private void OnDestroy()
    {
        InputController.Instance.Input.Player.Movement.performed -= SetDirection;

        InputController.Instance.Input.Player.Movement.canceled -= StopMovement;
    }

    private void FixedUpdate()
    {
        Move(_direct);
        LookAt(_camera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
    }

    private void LookAt(Vector3 target)
    {
        Vector3 dir = target - _transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        _transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Move(Vector2 direct)
    {
        _rigibody.velocity = _speed * direct;
    }

    private void StopMovement(InputAction.CallbackContext context)
    {
        _direct = Vector2.zero;
    }

    private void SetDirection(InputAction.CallbackContext context)
    {
        _direct = context.ReadValue<Vector2>();
    }

}
