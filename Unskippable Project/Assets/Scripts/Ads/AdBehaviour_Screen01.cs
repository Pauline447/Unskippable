using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdBehaviour_Screen01 : AdBehaviour
{
    protected override IEnumerator AppearingRoutine()
    {
        Debug.Log("Restart Routine");
        MakeAppear(0);
        yield return new WaitForSeconds(0.5f);
        MakeAppear(1);

        yield return new WaitForSeconds(10f);

        MakeAppear(2);
        yield return new WaitForSeconds(0.5f);
        MakeAppear(3);

        yield return new WaitForSeconds(8f);
        MakeAppear(0);
        yield return new WaitForSeconds(0.5f);
        MakeAppear(1);

        yield return new WaitForSeconds(8f);
        MakeAppear(4);

        StopCoroutine(m_appearingRoutine);
        m_appearingRoutine = StartCoroutine(AppearingRoutine());
    }
}
