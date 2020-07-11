using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaughtyLegController : MonoBehaviour
{
    public GameObject controller;

    void Update()
    {
        MoveLegNormally();

        if (Input.GetMouseButton(0))
        {

        }
    }

    private void MoveLegNormally()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            controller.transform.position = hit.point;
        }
    }
}
