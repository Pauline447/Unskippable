using UnityEngine;

public class SkipButtonBehaviour : MonoBehaviour
{
    protected PlayerController m_player;
    protected Vector3 m_playerPos;

    private bool buttonClickable;

    public bool ButtonClickable { get => buttonClickable; set => buttonClickable = value; }

    void Start()
    {
        m_player = PlayerController.Instance;
        ButtonClickable = false;

    }
    private void OnEnable()
    {
        PlayerController.Instance.OnInteract += CheckHit;
    }
    private void OnDisable()
    {
        PlayerController.Instance.OnInteract -= CheckHit;
    }
    private void CheckHit()
    {
        m_playerPos = m_player.transform.position;

        float distanceBetweenPosPlayer = Vector3.Distance(transform.position, m_playerPos);
        if (distanceBetweenPosPlayer < 1f && ButtonClickable)
        {
            AdManager.Instance.StartNextAd();
            Debug.Log("ButtonClicked");
        }
    }
}
