using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using KVR2023;

namespace KVR2023 //All classes can use this namespace to access the Modes enumeration. 
{
    public enum Criticality
    {
        Unskippable = 0,
        Skippable = 1,
    }
}

public class Task : MonoBehaviour
{
    public List<Task> subtasks;
    [field: SerializeField] public string TaskName { get; private set; }
    public int TaskID { get; set; }
    public bool IsActive { get; set; }
    public bool IsComplete { get; set; }
    [field: SerializeField] public int Crit { get; private set; }
    [SerializeField] private TaskManager taskManager;
    [SerializeField] private TaskImplementationBase taskImplementation;
    
    public void Start()
    {
        IsActive = false;
        IsComplete = false;
    }

    public void StartTask()
    {
        //Debug.Log("Successfully called task.StartTask.");
        IsActive = true;
        taskImplementation.StartTask();
    }

    public void CompleteTask()
    {
        //Debug.Log("Successfully called task.CompleteTask.");
        IsComplete = true;
        IsActive = false;
        taskManager.TaskCompletionUpdate();
    }

    public void SkipActiveTask()
    {
        IsActive = false;
        IsComplete = false;
        taskImplementation.StopTask();
        //Debug.Log("Successfully called task.SkipActiveTask.");
    }
}
