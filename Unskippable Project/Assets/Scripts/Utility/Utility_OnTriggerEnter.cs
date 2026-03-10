using UnityEngine;
using UnityEngine.Events;

public class Utility_OnTriggerEnter : MonoBehaviour
{
    [SerializeField] private string m_tag;
    [SerializeField] private bool m_destoryOtherObj;
    [SerializeField] private UnityEvent m_event;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == m_tag)
        {
            m_event.Invoke();

            if(m_destoryOtherObj)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
