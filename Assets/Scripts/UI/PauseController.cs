using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{

    [SerializeField]
    private GameObject obj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu(!obj.activeSelf);
        }
    }

    void TogglePauseMenu(bool active)
    {
        if (!active)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        obj.SetActive(active);
    }
}
