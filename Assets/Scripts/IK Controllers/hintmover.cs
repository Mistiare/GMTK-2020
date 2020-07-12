using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintmover : MonoBehaviour
{
    [SerializeField]
    private Transform controller;

    private void Update()
    {
        transform.position = new Vector3(controller.position.x + 3, controller.position.y + 3, controller.position.z);
    }
}
