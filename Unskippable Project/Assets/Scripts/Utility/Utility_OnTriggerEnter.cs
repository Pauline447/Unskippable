using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Utility_OnTriggerEnter : MonoBehaviour
{
    [SerializeField] private List<string> m_tag;
    [SerializeField] private bool m_destoryOtherObj;
    [SerializeField] private bool m_destoryThisObj;
    [SerializeField] private List<UnityEvent> m_event;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {

        for(int i =0; i < m_tag.Count; ++i)
        {
            if (collision.tag == m_tag[i])
            {
                m_event[i].Invoke();

                if(m_destoryOtherObj)
                {
                    Destroy(collision.gameObject);
                }
                if(m_destoryThisObj)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
