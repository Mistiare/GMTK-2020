using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private GameObject[] waypoints = null;
    [SerializeField]
    private float moveForce = 0f;
    [SerializeField]
    private float rotationSpeed = 0f;
    private Vector3 moveDir;
    private int currentWaypoint;
    [SerializeField]
    private int finalWaypoint;

    [SerializeField]
    private GameObject[] firstWaypoints = null;
    [SerializeField]
    private GameObject[] secondWaypoints = null;
    [SerializeField]
    private bool interating = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        waypoints = firstWaypoints;
        currentWaypoint = 0;
        finalWaypoint = waypoints.Length - 1;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDir * moveForce);
    }

    private void Update()
    {
        if (waypoints.Length > 0)
        {
            if (Vector3.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) >= 2f)
            {
                Vector3 direction = waypoints[currentWaypoint].transform.position - this.transform.position;
                direction.y = 0f;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);

                if (direction.magnitude > 0.8f)
                {
                    moveDir = direction.normalized;
                }
            }
            else if (currentWaypoint == finalWaypoint)
            {   
                if (!interating)
                {
                    moveDir = Vector3.zero;
                    waypoints = secondWaypoints;
                    currentWaypoint = 0;
                    finalWaypoint = waypoints.Length - 1;
                }
            }
            else
            {
                moveDir = Vector3.zero;
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            }
        }
    }

    public void DoingSomething(bool doingSomething)
    {
        interating = doingSomething;
    }

}
