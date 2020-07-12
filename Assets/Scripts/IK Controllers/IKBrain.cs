using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class IKBrain : MonoBehaviour
{
    public Transform[] feetPositions = new Transform[2];
    private float footHeight;
    public Transform balancePoint;
    public Transform spine;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private GameObject mainBody;

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
        footHeight = feetPositions[1].position.y;
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

        RaycastHit hit;
        if (Physics.Raycast(new Vector3(mainBody.transform.position.x, feetPositions[1].position.y + 1f, mainBody.transform.position.z), Vector3.down, out hit))
        {
            float diff = mainBody.transform.position.y - hit.point.y;
            mainBody.transform.position = new Vector3(mainBody.transform.position.x, mainBody.transform.position.y, mainBody.transform.position.z);
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
        position = new Vector3(balancePoint.position.x, footHeight, balancePoint.position.z);
        stepNormal = new Vector3(balancePoint.position.x, footHeight, balancePoint.position.z);

        return position;
    }
}
