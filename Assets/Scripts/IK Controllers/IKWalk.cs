using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKWalk : MonoBehaviour
{
    [SerializeField]
    private IKBrain brain;

    // Position of the foot
    [SerializeField]
    private Transform footPosition;

    [SerializeField]
    private bool isRightFoot;

}
