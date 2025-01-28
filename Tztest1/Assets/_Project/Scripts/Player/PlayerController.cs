using UnityEngine;
using PlayerInputControls;


public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerControls _playerInput;
    [SerializeField] private int _speedPlayer;

    [Header("Camera")]
    [SerializeField] private Camera _cameraPlayer;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _sensLook = 0.7f;

    private float _rotX;
    private float _rotY;

    private void Awake()
    {
        _playerInput = new PlayerControls();
        _cameraPlayer = Camera.main;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        OnMove();
        OnLook();
    }

    private void OnMove()
    {
        Vector2 input = _playerInput.PlayerLocomotion.Move.ReadValue<Vector2>();
        Vector3 move = _cameraTransform.right * input.x + _cameraTransform.forward * input.y;
        move.y = 0;
        _characterController.Move(move * _speedPlayer * Time.deltaTime);
    }

    private void OnLook()
    {
        Vector2 look = _playerInput.PlayerLocomotion.CameraLook.ReadValue<Vector2>();
        _rotX -= look.y * _sensLook;
        _rotX = Mathf.Clamp(_rotX, -40f, 40f);
        _rotY += look.x * _sensLook;
        _cameraPlayer.transform.rotation = Quaternion.Euler(_rotX, _rotY, 0);
    }
}
 
