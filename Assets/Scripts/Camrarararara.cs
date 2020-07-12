using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camrarararara : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private float rotateSpeed = 0;
    [SerializeField]
    private float maxHeight = 0;
    [SerializeField]
    private float minHeight = 0;


    void Update()
    {
        transform.LookAt(target);

        Vector3 up = new Vector3(target.position.x, target.position.y + 1, target.position.z);

        if (Input.GetKey(KeyCode.A))
        {
            target.Rotate(target.InverseTransformPoint(up), rotateSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            target.Rotate(target.InverseTransformPoint(up), -rotateSpeed);
        }


        float currentHeight = target.eulerAngles.x;

        if (currentHeight > 180)
        {
            currentHeight -= 360;
        }

        if (Input.GetKey(KeyCode.W) && currentHeight < maxHeight)
        {
            target.Rotate(Vector3.right, rotateSpeed);
        }

        if (Input.GetKey(KeyCode.S) && currentHeight > minHeight)
        {
            target.Rotate(Vector3.right, -rotateSpeed);
        }
    }
}
