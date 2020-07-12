using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    public void OnMouseDown()
    {
        anim.SetTrigger("Credits");
    }
}
