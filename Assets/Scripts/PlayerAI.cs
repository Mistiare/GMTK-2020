﻿using System.Collections;
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
    private int currentPatrol;

    [SerializeField]
    private GameObject[] patrols = null;
    [SerializeField]
    private bool interating = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        ChangePatrol(0);
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDir * moveForce);
    }

    private void Update()
    {
        if (waypoints.Length > 0)
        {
            if (!interating)
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

                    currentPatrol = (currentPatrol + 1);
                    ChangePatrol(currentPatrol);
                    moveDir = Vector3.zero;
                }
                else
                {
                    moveDir = Vector3.zero;
                    currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                }

            }
            else
            {
                moveDir = Vector3.zero;
            }
        }
    }

    public void DoingSomething(bool doingSomething)
    {
        interating = doingSomething;
    }

    private void ChangePatrol(int patrolRoute)
    {
        if (currentPatrol < patrols.Length)
        {
            int children = patrols[patrolRoute].transform.childCount;
            waypoints = new GameObject[children];

            for (int i = 0; i < children; i++)
            {
                waypoints[i] = patrols[patrolRoute].transform.GetChild(i).gameObject;
            }

            currentWaypoint = 0;
            finalWaypoint = waypoints.Length - 1;
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }

}
