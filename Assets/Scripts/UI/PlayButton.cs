using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

    [SerializeField]
    int playBuildIndex;

    public void OnMouseDown()
    {
        SceneManager.LoadScene(playBuildIndex);
    }
}
