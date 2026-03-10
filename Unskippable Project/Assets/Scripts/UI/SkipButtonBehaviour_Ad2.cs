using UnityEngine;

public class SkipButtonBehaviour_Ad2 : SkipButtonBehaviour
{
    [SerializeField] private float m_maxDistance;
    [SerializeField] private Animator m_animDemon;

    private string m_eatAnimString = "Demon_Ad2_EatSkip";

    void Update()
    {
        if(ButtonClickable)
        { 
            return;
        }

        m_playerPos = m_player.transform.position;

        float distanceBetweenPosPlayer = Vector3.Distance(transform.position, m_playerPos);

        if (distanceBetweenPosPlayer < m_maxDistance)
        {
            m_animDemon.Play(m_eatAnimString);
            this.gameObject.SetActive(false);
        }
    }
}
