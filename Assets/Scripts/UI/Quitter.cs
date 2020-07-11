using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitter : MonoBehaviour
{

    [SerializeField]
    GameObject arrowUI;
    [SerializeField]
    GameObject quitButtonUI;

    public void OnMouseDown()
    {
        arrowUI.SetActive(true);
        quitButtonUI.SetActive(false);
    }

}
