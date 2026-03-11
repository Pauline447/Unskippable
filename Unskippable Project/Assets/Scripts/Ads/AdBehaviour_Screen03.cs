using System.Collections;
using UnityEngine;

public class AdBehaviour_Screen03 : AdBehaviour
{
    protected override IEnumerator AppearingRoutine()
    {
        yield return new WaitForSeconds(8f);
        MakeReviewAppear(0);
    }
}
