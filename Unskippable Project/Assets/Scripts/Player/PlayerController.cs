using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_cursorSpeed;

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
    void Start()
    {
        Cursor.visible = false;
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

    private void Update()
    {
        Vector3 target = GetPlayerPos();

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            m_cursorSpeed * Time.deltaTime
        );

        Vector3 pos = transform.position;

        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
}
