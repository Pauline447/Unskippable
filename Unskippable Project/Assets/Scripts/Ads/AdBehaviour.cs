using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdBehaviour : MonoBehaviour
{
    [SerializeField] UI_TimerText m_skipTimer;
    [SerializeField] int m_currentAdID;

    [SerializeField] private bool m_appearingObjs;
    [SerializeField] private List<GameObject> m_Prefabs;
    [SerializeField] private List<Transform> m_Pos;
    [SerializeField] private Transform m_parent;

    private Coroutine m_appearingRoutine;

    private void OnEnable()
    {
        m_skipTimer.gameObject.SetActive(true);
        m_skipTimer.CurrentAd = m_currentAdID;

        if(!m_appearingObjs)
        {
            return;
        }

        if (m_appearingRoutine != null)
        {
            StopCoroutine(m_appearingRoutine);
        }
        m_appearingRoutine = StartCoroutine(AppearingRoutine());
    }

    public void MakeReviewAppear(int reviewInt)
    {
        GameObject review = Instantiate(m_Prefabs[reviewInt], m_parent);
        review.transform.position = m_Pos[reviewInt].position;
    }

    protected virtual IEnumerator AppearingRoutine()
    {
        yield return new WaitForSeconds(1f);
    }
}
