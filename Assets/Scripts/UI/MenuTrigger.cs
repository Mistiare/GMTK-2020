using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTrigger : MonoBehaviour
{

    [SerializeField]
    int playBuildIndex;
    [SerializeField]
    private Animator anim;

    private enum menuOptions
    {
        Play,
        Options,
        Credits,
        Quit
    }

    [SerializeField]
    private menuOptions option;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (option)
            {
                case menuOptions.Play:
                    anim.SetTrigger("Play");
                    SceneManager.LoadScene(playBuildIndex);
                    break;

                case menuOptions.Options:
                    anim.SetTrigger("Options");
                    break;

                case menuOptions.Credits:
                    anim.SetTrigger("Credits");
                    break;

                case menuOptions.Quit:
                    anim.SetTrigger("Quit");
                    Application.Quit();
                    break;
            }
        }
    }

#if UNITY_EDITOR
    #region Debugging
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("Play");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("Options");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("Credits");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetTrigger("Quit");
        }   
    }
    #endregion
#endif
}
