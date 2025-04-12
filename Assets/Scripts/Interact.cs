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
        PLEASE(new InputAction.CallbackContext());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PLEASE(InputAction.CallbackContext context)
    {

        Debug.Log("Interact HIT");

    }

    private void Awake()
    {
        playerControls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        interact = playerControls.Player.Interact;
        interact.performed += PLEASE;
        playerControls.Player.Interact.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Interact.Disable();
    }

}
