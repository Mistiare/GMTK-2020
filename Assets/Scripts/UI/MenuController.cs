using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    private Animator anim;
    [SerializeField]
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("MenuView"))
            {
                obj.SetActive(!obj.activeSelf);
            }
            else
            {
                anim.SetTrigger("Return");
            }
        }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("MenuView") && obj.activeSelf)
        {
            obj.SetActive(false);
        }
    }
}
