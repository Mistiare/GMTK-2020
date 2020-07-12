using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    public void OnMouseDown()
    {
        anim.SetTrigger("Options");
    }
}
