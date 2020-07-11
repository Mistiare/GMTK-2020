using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKBrain : MonoBehaviour
{
    public bool stepWithRightFoot = true;

    public Transform[] feetPositions = new Transform[2];
    public Transform balancePoint;

    void Step()
    {
        // Switches foot to step with
        stepWithRightFoot = !stepWithRightFoot;
    }
}
