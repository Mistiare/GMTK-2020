using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKBrain : MonoBehaviour
{
    public Transform[] feetPositions = new Transform[2];
    private float footStartHeight;
    public Transform balancePoint;

    [SerializeField]
    private bool stepping;

    private Vector3 stepPoint;
    private Vector3 worldVelocity = Vector3.right;
    private Vector3 worldTarget = Vector3.zero;
    private Vector3 restingPosition = Vector3.forward;
    private Vector3 stepNormal;

    [SerializeField]
    private AnimationCurve stepHeightCurve;

    public float strideLength;
    [SerializeField]
    private float stepCooldown = 1f;
    [SerializeField]
    private float stepDuration = .5f;
    private float stepHeightMultiplier = .25f;
    private float lastStep = 0;
    private Vector3 centerOfBalance;

    public float percent
    {
        get
        {
            return Mathf.Clamp01((Time.time - lastStep) / stepDuration);
        }
    }

    private void Start()
    {
        lastStep = Time.time + stepCooldown;
        restingPosition = feetPositions[1].position;
        footStartHeight = feetPositions[1].position.y;
    }

    private void Update()
    {
        StepCheck();

        if (stepping)
        {
            stepPoint = AdjustPosition(new Vector3(balancePoint.position.x, feetPositions[1].position.y, balancePoint.position.z) + worldVelocity);
            feetPositions[1].position = Vector3.Lerp(feetPositions[1].position, stepPoint, percent) + new Vector3(balancePoint.position.x, feetPositions[1].position.y, balancePoint.position.z)  * stepHeightCurve.Evaluate(percent) * stepHeightMultiplier;

            if (Vector3.Distance(centerOfBalance, feetPositions[1].position) <= .05)
            {
                stepping = false;
            }
        }
    }

    private void StepCheck()
    {
        centerOfBalance = new Vector3(balancePoint.position.x, feetPositions[1].position.y, balancePoint.position.z);
        if (Vector3.Distance(centerOfBalance, feetPositions[1].position) >= strideLength && !stepping)
        {
            stepping = true;
            lastStep = Time.time;
        }
    }

    public void MoveVelocity(Vector3 newVelocity)
    {
        worldVelocity = Vector3.Lerp(worldVelocity, newVelocity, 1f - percent);
    }

    public Vector3 AdjustPosition(Vector3 position)
    {
        Vector3 direction = position - balancePoint.position;
        RaycastHit hit;
        Ray ray = new Ray(feetPositions[1].position, Vector3.down);
        
        Debug.DrawLine(balancePoint.position, restingPosition, Color.red, 0f);
        position = new Vector3(balancePoint.position.x, footStartHeight, balancePoint.position.z);
        stepNormal = new Vector3(balancePoint.position.x, footStartHeight, balancePoint.position.z);

        return position;
    }
}
