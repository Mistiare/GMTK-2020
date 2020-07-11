using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKWalk : MonoBehaviour
{
    [SerializeField]
    private IKBrain brain;

    // Position of the foot
    [SerializeField]
    private Transform footPosition;

    [SerializeField]
    private bool isRightFoot;

    [Range(0, 1)]
    public float stepLength;

    private void Update()
    {
        print(brain.balancePoint.position.z - footPosition.position.z);
        if (brain.stepWithRightFoot == isRightFoot && Mathf.Abs(brain.balancePoint.position.z - footPosition.position.z) >= stepLength) 
        {
            print("Take a step");
        }
    }
}
