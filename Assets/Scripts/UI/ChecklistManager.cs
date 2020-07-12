using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegDay.Data;
using TMPro;
using UnityEngine.UI;

public class ChecklistManager : MonoBehaviour
{

    [SerializeField]
    Checklist checklistData;
    [SerializeField]
    GameObject taskPrefab;
    Canvas canvas;

    static List<GameObject> taskList = new List<GameObject>{};

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        for (int i=0; i<checklistData.tasks.Length; i++)
        {
            GameObject task = Instantiate(taskPrefab, gameObject.transform);
            task.transform.localPosition = new Vector3(0, -50 * i, 0);
            task.GetComponentInChildren<TextMeshProUGUI>().text = checklistData.tasks[i].taskName;
            taskList.Add(task);
        }
    }

    public static void UpdateTask(int i)
    {
        taskList[i].GetComponentInChildren<Toggle>().isOn = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            canvas.enabled = !canvas.enabled;
        }
    }
}
