using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaughtyLegController : MonoBehaviour
{
    public GameObject controller;
    public GameObject spineController;
    [SerializeField]
    private float speed;

    void Update()
    {
        MoveLegNormally();
    }

    private void MoveLegNormally()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            controller.transform.position = hit.point;
            var hitNoY = new Vector3(hit.point.x, 0, hit.point.z);
            var spineNoY = new Vector3(spineController.transform.position.x, 0, spineController.transform.position.z);
            if (Vector3.Distance(hitNoY, spineNoY) >= 1f)
            {
                Vector3 directionVector = hitNoY - spineNoY;
                spineController.gameObject.GetComponent<Rigidbody>().velocity = directionVector.normalized * speed;
            }
        }
    }
}
