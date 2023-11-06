using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Task1 : TaskImplementationBase
{
    [SerializeField] private Task task;
    [SerializeField] private GameObject taskObjectOther;
    [SerializeField] private TextUpdateManager textUpdateManager;

    public override void StartTask()
    {
        string instructions = "Click on the sphere.";
        textUpdateManager.TriggerTextUpdate(instructions);
        gameObject.SetActive(true);
        taskObjectOther.SetActive(true);
    }

    public override void StopTask()
    {
        gameObject.SetActive(false);
        taskObjectOther.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (task.IsActive)
        {
            gameObject.SetActive(false);
            taskObjectOther.SetActive(false);
            task.CompleteTask();
        }
    }
}
