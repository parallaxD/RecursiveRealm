
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;


    public static Camera PlayerCamera;

    public GameObject NoteBook;

    public float Fov = 60f;
    public float MouseSensitivity = 2f;
    public float MaxLookAngle = 50f;


    private float _yaw = 0.0f;
    private float _pitch = 0.0f;


    public bool HoldToZoom = false;
    public KeyCode ZoomKey = KeyCode.Mouse1;
    public float ZoomFOV = 30f;
    public float ZoomStepTime = 5f;
    private bool IsZoomed = false;

    public float WalkSpeed = 0.0f;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        PlayerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();

        PlayerCamera.fieldOfView = Fov;

    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (GameManager.IsGamePaused || GameManager.CurrentPart == GameManager.GameParts.FifthPart)
        {
            return;
        }
        if (InputManager.PlayerActions.OpenNoteBook.triggered && GameManager.IsPlayerHasNotebook && !GameManager.IsSomeBookOpen)
        {
            GameManager.IsGamePaused = true;
            GameManager.IsSomeBookOpen = true;
            Cursor.lockState = CursorLockMode.None;
            NoteBook.SetActive(true);
        }
        else
        {
            NoteBook.SetActive(false);
        }

        _yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * MouseSensitivity;

        _pitch -= MouseSensitivity * Input.GetAxis("Mouse Y");
        _pitch = Mathf.Clamp(_pitch, -MaxLookAngle, MaxLookAngle);

        transform.localEulerAngles = new Vector3(0, _yaw, 0);
        PlayerCamera.transform.localEulerAngles = new Vector3(_pitch, 0, 0);

        if (InputManager.PlayerActions.Zoom.triggered && !HoldToZoom)
        {
            if (!IsZoomed)
            {
                IsZoomed = true;
            }
            else
            {
                IsZoomed = false;
            }
        }

        if (HoldToZoom)
        {
            if (Input.GetKeyDown(ZoomKey))
            {
                IsZoomed = true;
            }
            else if (Input.GetKeyUp(ZoomKey))
            {
                IsZoomed = false;
            }
        }

        if (IsZoomed)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, ZoomFOV, ZoomStepTime * Time.deltaTime);
        }
        else if (!IsZoomed)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, Fov, ZoomStepTime * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.CurrentPart == GameManager.GameParts.FifthPart)
        {
            return;
        }
        if (GameManager.IsGamePaused)
        {
            _rb.velocity = Vector3.zero;
            return;
        }
        Vector3 targetVelocity = InputManager.PlayerActions.Move.ReadValue<Vector3>();

        targetVelocity = transform.TransformDirection(targetVelocity) * WalkSpeed;
        Vector3 velocity = _rb.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);

        _rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}