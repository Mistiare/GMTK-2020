using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//Also requires some sort of collider, made with an AABB in mind

/// The class that takes care of all the player related physics
/// Many configurable parameters with defaults set as the recommended values in BBR
public class StepUp : MonoBehaviour
{

    [Header("Steps")]
    public float maxStepHeight = 0.4f;              
    public float stepSearchOvershoot = 0.01f;       

    private List<ContactPoint> allCPs = new List<ContactPoint>();
    private Vector3 lastVelocity;

    void FixedUpdate()
    {
        Vector3 velocity = this.GetComponent<Rigidbody>().velocity;

        ContactPoint groundCP = default(ContactPoint);
        bool grounded = FindGround(out groundCP, allCPs);

        Vector3 stepUpOffset = default(Vector3);
        bool stepUp = false;
        if (grounded)
            stepUp = FindStep(out stepUpOffset, allCPs, groundCP, velocity);

        //Steps
        if (stepUp)
        {
            this.GetComponent<Rigidbody>().position += stepUpOffset;
            this.GetComponent<Rigidbody>().velocity = lastVelocity;
        }

        allCPs.Clear();
        lastVelocity = velocity;
    }

    void OnCollisionEnter(Collision col)
    {
        allCPs.AddRange(col.contacts);
    }

    void OnCollisionStay(Collision col)
    {
        allCPs.AddRange(col.contacts);
    }

    bool FindGround(out ContactPoint groundCP, List<ContactPoint> allCPs)
    {
        groundCP = default(ContactPoint);
        bool found = false;
        foreach (ContactPoint cp in allCPs)
        {
            //Pointing with some up direction
            if (cp.normal.y > 0.0001f && (found == false || cp.normal.y > groundCP.normal.y))
            {
                groundCP = cp;
                found = true;
            }
        }

        return found;
    }

    bool FindStep(out Vector3 stepUpOffset, List<ContactPoint> allCPs, ContactPoint groundCP, Vector3 currVelocity)
    {
        stepUpOffset = default(Vector3);

        Vector2 velocityXZ = new Vector2(currVelocity.x, currVelocity.z);
        if (velocityXZ.sqrMagnitude < 0.0001f)
            return false;

        foreach (ContactPoint cp in allCPs)
        {
            bool test = ResolveStepUp(out stepUpOffset, cp, groundCP);
            if (test)
                return test;
        }
        return false;
    }

    bool ResolveStepUp(out Vector3 stepUpOffset, ContactPoint stepTestCP, ContactPoint groundCP)
    {
        stepUpOffset = default(Vector3);
        Collider stepCol = stepTestCP.otherCollider;

        if (Mathf.Abs(stepTestCP.normal.y) >= 0.01f)
        {
            return false;
        }

        if (!(stepTestCP.point.y - groundCP.point.y < maxStepHeight))
        {
            return false;
        }

        RaycastHit hitInfo;
        float stepHeight = groundCP.point.y + maxStepHeight + 0.001f;
        Vector3 stepTestInvDir = new Vector3(-stepTestCP.normal.x, 0, -stepTestCP.normal.z).normalized;
        Vector3 origin = new Vector3(stepTestCP.point.x, stepHeight, stepTestCP.point.z) + (stepTestInvDir * stepSearchOvershoot);
        Vector3 direction = Vector3.down;
        if (!(stepCol.Raycast(new Ray(origin, direction), out hitInfo, maxStepHeight)))
        {
            return false;
        }

        Vector3 stepUpPoint = new Vector3(stepTestCP.point.x, hitInfo.point.y + 0.1f, stepTestCP.point.z) + (stepTestInvDir * stepSearchOvershoot);
        Vector3 stepUpPointOffset = stepUpPoint - new Vector3(stepTestCP.point.x, groundCP.point.y, stepTestCP.point.z);

        stepUpOffset = stepUpPointOffset;
        return true;
    }
}