using NUnit.Framework;
using UnityEngine;

using UnityEngine.InputSystem;


public class Interactor : MonoBehaviour
{

    public Transform cameraPos;
    public float range;
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

        if (Physics.Raycast(cameraPos.position, cameraPos.TransformDirection(Vector3.forward), out hit, range))
        {
            if(hit.collider.gameObject.TryGetComponent(out IInteract interact))
            {
                interact.Interact();
            }
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
