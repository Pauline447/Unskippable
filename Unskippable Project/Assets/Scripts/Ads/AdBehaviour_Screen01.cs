using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdBehaviour_Screen01 : AdBehaviour
{
    protected override IEnumerator AppearingRoutine()
    {
        yield return new WaitForSeconds(6f);
        MakeReviewAppear(0);
        yield return new WaitForSeconds(5f);
        MakeReviewAppear(1);
        yield return new WaitForSeconds(10f);
        MakeReviewAppear(2);
    }
}
