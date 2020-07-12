using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKBrain : MonoBehaviour
{
    public bool stepWithRightFoot = true;

    public Transform[] feetPositions = new Transform[2];
    public Transform balancePoint;

    public CapsuleCollider stepRadius;
    public float strideLength;

    private void Update()
    {
        
    }

    private void StepCheck()
    {
        Vector3 centerOfBalance = new Vector3(balancePoint.position.x, FootToUse().position.y, balancePoint.position.z);
        if (Vector3.Distance(centerOfBalance, FootToUse().position) >= strideLength)
        {
            TakeStep();
        }
    }

    private Transform FootToUse()
    {
        switch (stepWithRightFoot)
        {
            case true:
                return feetPositions[0];

            case false:
                return feetPositions[1];

            default:
                return feetPositions[0];
        }
    }

    private void TakeStep()
    {
        stepWithRightFoot = !stepWithRightFoot;
    }
}
