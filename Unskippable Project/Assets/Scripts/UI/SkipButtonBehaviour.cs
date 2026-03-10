using UnityEngine;

public class SkipButtonBehaviour : MonoBehaviour
{
    protected PlayerController m_player;
    protected Vector3 m_playerPos;

    protected bool m_buttonClickable;
    void Start()
    {
        m_player = PlayerController.Instance;
        m_buttonClickable = false;

        PlayerController.Instance.OnInteract += CheckHit;
    }

    private void CheckHit()
    {
        m_playerPos = m_player.transform.position;

        float distanceBetweenPosPlayer = Vector3.Distance(transform.position, m_playerPos);
        if (distanceBetweenPosPlayer < 1f && m_buttonClickable)
        {
            AdManager.Instance.StartNextAd();
            Debug.Log("ButtonClicked");
        }
    }
}
