using UnityEngine;

public class SkipButtonBehaviour_Ad3 : SkipButtonBehaviour
{
    [SerializeField] private float m_maxDistance;
    [SerializeField] private GameObject m_fire;
    void Update()
    {
        if (ButtonClickable)
        {
            return;
        }

        m_playerPos = m_player.transform.position;

        float distanceBetweenPosPlayer = Vector3.Distance(transform.position, m_playerPos);

        if (distanceBetweenPosPlayer < m_maxDistance && !m_fire.activeInHierarchy)
        {
            m_fire.SetActive(true);
        }
    }
}
