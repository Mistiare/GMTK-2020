using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKBrain : MonoBehaviour
{
    public Transform[] feetPositions = new Transform[2];
    public Transform balancePoint;

    public float strideLength;
    [SerializeField]
    private float stepCooldown = 1f;
    [SerializeField]
    private float stepDuration = .5f;
    private float lastStep = 0;

    private void Start()
    {
        lastStep = Time.time + stepCooldown;
    }

    private void Update()
    {
        StepCheck();
    }

    private void StepCheck()
    {
        Vector3 centerOfBalance = new Vector3(balancePoint.position.x, feetPositions[1].position.y, balancePoint.position.z);
        if (Vector3.Distance(centerOfBalance, feetPositions[1].position) >= strideLength)
        {
            StartCoroutine("TakeStep");
        }
    }

    private IEnumerable TakeStep()
    {
        Vector3 desiredPosition = balancePoint.position;

        float percent = Mathf.Clamp01((Time.time - lastStep) / stepDuration);
        feetPositions[1].position = Vector3.Lerp(feetPositions[1].position, desiredPosition, percent);

        yield return new WaitForEndOfFrame();
        StartCoroutine("TakeStep");
    }
}
