using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public InputAction walkInput;
    public InputAction jumpInput;

    public event Action<float> OnMoveInputRecieved;
    public event Action OnJumpInputRecieved;

    private void Start()
    {
        walkInput.Enable();
        jumpInput.Enable();

        walkInput.performed += WalkInput;
        walkInput.canceled += WalkInput;

        jumpInput.performed += JumpInput;


    }

    private void WalkInput(InputAction.CallbackContext callbackContext)
    {
        OnMoveInputRecieved?.Invoke(callbackContext.ReadValue<float>());
    }

    private void JumpInput(InputAction.CallbackContext callbackContext)
    {
        OnJumpInputRecieved?.Invoke();
    }
}
