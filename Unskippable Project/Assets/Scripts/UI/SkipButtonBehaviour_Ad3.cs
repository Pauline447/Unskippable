using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkipButtonBehaviour_Ad3 : SkipButtonBehaviour
{
    [SerializeField] private float m_maxDistance;
    [SerializeField] private GameObject m_fire;
    [SerializeField] private UnityEvent m_enoughTearsEvent;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="U")
        {
            if(collision.GetComponentInChildren<Slider>().value > 0.5f)
            {
                m_enoughTearsEvent.Invoke();
            }
        }
    }
}
