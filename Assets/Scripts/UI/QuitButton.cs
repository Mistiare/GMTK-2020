using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    public void OnMouseDown()
    {
        anim.SetTrigger("Quit");
    }
}
