using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput m_playerInput;

    private InputAction m_interactAction; //click screen
    private InputAction m_positionAction; //mouse position
    
    public event Action OnInteract;
    public event Action OnInteractionStopped;

    #region Singelton
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("PlayerController is null");
            }

            return instance;
        }
    }

    #endregion
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one PlayerController in the scnene!");
        }

        instance = this;

        m_playerInput = GetComponent<PlayerInput>();
        m_positionAction = m_playerInput.actions["Position"];
        m_interactAction = m_playerInput.actions["Interact"];
    }
    private void OnEnable()
    {
        m_interactAction.performed += InteractionEvent;
        m_interactAction.canceled += InteractionStoppedEvent;
    }
    private void OnDisable()
    {
        m_interactAction.performed -= InteractionEvent;
        m_interactAction.canceled -= InteractionStoppedEvent;
    }

    private void InteractionEvent(InputAction.CallbackContext context)
    {
        OnInteract?.Invoke();
    }
    private void InteractionStoppedEvent(InputAction.CallbackContext context)
    {
        OnInteractionStopped?.Invoke();
    }
    public Vector2 GetPlayerActionValue()
    {
        return m_positionAction.ReadValue<Vector2>();
    }

    public Vector2 GetTouchPos()
    {
        return m_positionAction.ReadValue<Vector2>();
    }

    public Vector2 GetPlayerPos()
    {
        return Camera.main.ScreenToWorldPoint(m_positionAction.ReadValue<Vector2>());
    }
    public void DeactivatePlayerInput(string[] inputs)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            GetComponent<PlayerInput>().actions[inputs[i]].Disable();
        }
    }
    public void ActivatePlayerInput(string[] inputs)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            GetComponent<PlayerInput>().actions[inputs[i]].Enable();
        }
    }
}
