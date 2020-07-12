using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuReturn : MonoBehaviour
{

    [SerializeField]
    int menuBuildIndex;

    public void OnMouseDown()
    {
        SceneManager.LoadScene(menuBuildIndex);
    }
}
