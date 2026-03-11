using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdBehaviour_Screen02 : AdBehaviour
{
    protected override IEnumerator AppearingRoutine()
    {
        yield return new WaitForSeconds(8f);
        MakeAppear(0);
    }
}
