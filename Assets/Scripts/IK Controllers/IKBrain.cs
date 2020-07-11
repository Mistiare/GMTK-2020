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

    void Step()
    {


        // Switches foot to step with
        stepWithRightFoot = !stepWithRightFoot;
        stepRadiusUpdate();
    }

   
    /// <summary>
    /// Finds which foot to use
    /// </summary>
    /// <param name="current">Pass true if you want the front foot, false for the back foot</param>
    /// <returns>Index of the correct foot</returns>
    private int FootToUse(bool current)
    {
        if ((stepWithRightFoot && current) || (!stepWithRightFoot && !current))
        {
            return 0;
        }

        else if ((!stepWithRightFoot && current) || (stepWithRightFoot && !current))
        {
            return 1;
        }

        // Shouldn't be used
        else
        {
            return -1;
        }
    }

    //private void Update()
    //{
    //    if (stepRadius.radius >= CheckStepRadius())
    //    {
    //        Step();
    //    }

    //}

    private void stepRadiusUpdate()
    {
        Transform foot = feetPositions[FootToUse(false)];
        Vector3 directionToFoot = balancePoint.position - foot.position;
        directionToFoot.y = 0;
        stepRadius.radius = directionToFoot.magnitude;
    }
    private float CheckStepRadius()
    {
        Transform foot = feetPositions[FootToUse(false)];
        Vector3 directionToFoot = balancePoint.position - foot.position;
        directionToFoot.y = 0;
        return directionToFoot.magnitude;
    }
}
