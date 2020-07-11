using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegControlSwitcher : MonoBehaviour
{
    public MonoBehaviour UseTheKnee;
    public MonoBehaviour NoKnees;

    private bool knees = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ToggleKneeCaps();
        }
    }

    private void ToggleKneeCaps()
    {
        knees = !knees;
        UseTheKnee.enabled = knees;
        NoKnees.enabled = !knees;
    }
}
