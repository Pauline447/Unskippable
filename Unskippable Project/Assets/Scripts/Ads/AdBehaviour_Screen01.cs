using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdBehaviour_Screen01 : AdBehaviour
{
    [SerializeField] private List<GameObject> m_reviewPrefabs;
    [SerializeField] private List<Transform> m_reviewPos;
    [SerializeField] private Transform m_parentReview;

    private Coroutine m_reviewsAppearingRoutine;
    private void Start()
    {
        m_reviewsAppearingRoutine = StartCoroutine(ReviewsAppearingRoutine());
    }

    public void MakeReviewAppear(int reviewInt)
    {
        GameObject review = Instantiate(m_reviewPrefabs[reviewInt], m_parentReview);
        review.transform.position = m_reviewPos[reviewInt].position;
    }

    private IEnumerator ReviewsAppearingRoutine()
    {
        yield return new WaitForSeconds(5f);
        MakeReviewAppear(0);
        yield return new WaitForSeconds(5f);
        MakeReviewAppear(1);
        yield return new WaitForSeconds(10f);
        MakeReviewAppear(2);
    }

}
