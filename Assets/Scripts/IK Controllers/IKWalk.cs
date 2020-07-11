using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKWalk : MonoBehaviour
{
    [SerializeField]
    private IKBrain brain;

    // Center of balance
    [SerializeField]
    private Transform balancePoint;
    // Position of the foot
    [SerializeField]
    private Transform footPosition;

    [SerializeField]
    private bool isRightFoot;

    // Distance between footPosition and balancePoint before taking a step
    [Range(0, 1)]
    public float steplength;

    public bool legGrounded = false;
    public Vector3 stepPoint;
    public Vector3 stepNormal;

    public Vector3 optimalRestingPosition = Vector3.forward;
    public Vector3 restingPosition
    {
        get
        {
            return transform.TransformPoint(optimalRestingPosition);
        }
    }
    public Vector3 worldVelocity = Vector3.right;

    public Vector3 desiredPosition
    {
        get
        {
            return restingPosition + worldVelocity + (Random.insideUnitSphere * placementRandomization);
        }
    }

    public Vector3 worldTarget = Vector3.zero;
    public Transform ikTarget;
    public Transform ikPoleTarget;

    public float placementRandomization = 0;

    public bool autoStep = true;

    public LayerMask solidLayer;
    public float stepRadius = 0.25f;
    public AnimationCurve stepHeightCurve;
    public float stepHeightMultiplier = 0.25f;
    public float stepCooldown = 1f;
    public float stepDuration = 0.5f;
    public float stepOffset;
    public float lastStep = 0;

    public float percent
    {
        get
        {
            return Mathf.Clamp01((Time.time - lastStep) / stepDuration);
        }
    }

    private void Update()
    {
        print(balancePoint.position.z - footPosition.position.z);
        if (brain.rightFoot == isRightFoot && Mathf.Abs(balancePoint.position.z - footPosition.position.z) >= steplength) 
        {
            print("Take a step");
        }
    }
}
