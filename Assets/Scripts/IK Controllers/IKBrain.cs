using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKBrain : MonoBehaviour
{
    public bool rightFoot = true;

    void Step()
    {
        // Switches foot to step with
        rightFoot = !rightFoot;
    }
}
