using UnityEngine;

using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{

    public Transform cameraPos;
    private InputAction interact;
    private InputSystem_Actions playerControls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractAttempt(InputAction.CallbackContext context)
    {
        RaycastHit hit;

        if (Physics.Raycast(cameraPos.position, cameraPos.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            
            Debug.DrawRay(cameraPos.position, cameraPos.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }

    }

    private void Awake()
    {
        playerControls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        interact = playerControls.Player.Interact;
        interact.performed += InteractAttempt;
        playerControls.Player.Interact.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Interact.Disable();
    }

}
