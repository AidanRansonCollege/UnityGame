using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Assignables")]
    public Rigidbody rb;
    public InputSystem_Actions playerControls;
    public Camera camera;
    public GameObject cameraPos;

    [Header("Changables")]
    public float movespeed;
    public float sensX;
    public float sensY;

    [Header("Info")]
    public Vector2 moveDirection;
    public Vector3 moveVector;

    private float yRotation;
    private float xRotation;

    //Input Actions
    private InputAction move;
    private InputAction fire;
    private InputAction look;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {

        camera.transform.position = cameraPos.transform.position;
        float mouseX = look.ReadValue<Vector2>().x * sensX;
        float mouseY = look.ReadValue<Vector2>().y * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        camera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        gameObject.transform.rotation = Quaternion.Euler(0, yRotation, 0);

        
    }

    private void FixedUpdate()
    {
        moveDirection = move.ReadValue<Vector2>().normalized;
        moveVector = gameObject.transform.forward * moveDirection.y + gameObject.transform.right * moveDirection.x;
        rb.linearVelocity = moveVector * movespeed;
    }



    //INPUT SYSTEM STUFF
    private void Awake()
    {
        playerControls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        look = playerControls.Player.Look;
        playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
    }

}
