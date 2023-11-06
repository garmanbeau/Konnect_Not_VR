using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using KVR2023;

namespace KVR2023
{
    public enum Modes
    {
        Sandbox = 0,
        Instruction = 1,
        Test = 2
    }

    public struct CurrentTaskTextUpdate
    {
        private string taskName;
        private int taskID;
        private bool isComplete;
        private bool isActive;
        private string currentMode;

        public CurrentTaskTextUpdate(string TaskName, int TaskID, bool IsActive, bool IsComplete, string CurrentMode)
        {
            taskName = TaskName;
            taskID = TaskID;
            isActive = IsActive;
            isComplete = IsComplete;
            currentMode = CurrentMode;
        }

        public override string ToString() //Overriding the method so that we can format the contents of the text update.
        {
            return $"Task Name: {taskName}\nTask ID: {taskID}\nTask is Active: {isComplete}\nTask is Complete: {isComplete}\nCurrent Mode: {currentMode}";
        }
    }
}

public class TaskManager : MonoBehaviour
{
    public List<Task> tasks;
    [SerializeField] private Task initialTask;
    private Task currentTask;
    [SerializeField] private TextUpdateManager textUpdateManager;
    private string CurrentMode { get; set; }
    private int taskIndex;

    void Start()
    {
        if (initialTask != null) //If initialTask is set in the inspector...
        {
            currentTask = initialTask;
        }
        else if (tasks != null) //else if there are tasks stored in the list...
        {
            Debug.Log("initialTask is null");
            currentTask = tasks[0]; //Set the current task to the first task in the list.
        }
        int count = 0; //Define a local variable which is used in the loop to set the TaskID for each task and the taskIndex of the initialTask.
        foreach (Task task in tasks)
        {
            if (task == initialTask) //If a task in the list is the initialTask...
            {
                taskIndex = count; //Set taskIndex.
            }
            task.TaskID = count;
            count++; //Increment indexCount before the next loop iteration.
        }
    }

    public void ActivateTaskManager(int mode) //Called when the user presses a button in the tablet mode select page.
    {
        switch ((Modes)mode)
        {
            case Modes.Sandbox:
            { 
                CurrentMode = "Sandbox";
                break;
            }
            case Modes.Instruction:
            {
                CurrentMode = "Instruction";
                break;
            }
            case Modes.Test:
            {
                CurrentMode = "Test";
                break;
            }
            default:
            {
                CurrentMode = "Undefined";
                break;
            }
        }
    }

    public void NextTask() //Does not start the task.  This can be used for selecting a specific task in sandbox Mode.
    {
        if (taskIndex < tasks.Count - 1)
        {
            if (currentTask.IsActive)
            {
                currentTask.SkipActiveTask();
            }
            currentTask.IsActive = false;
            taskIndex++;
            currentTask = tasks[taskIndex];
            TextUpdateCurrentTask();
        }
        else
        {
            //Let the user know that there is not a next task.
        }
    }

    public void PreviousTask() //Does not start the task.  This can be used for selecting a specific task in sandbox mode.
    {
        if (taskIndex > 0)
        {
            currentTask.IsActive = false;
            taskIndex--;
            currentTask = tasks[taskIndex];
            TextUpdateCurrentTask();
        }
        else
        {
            //Let the user know that there is not a previous task.
        }
    }

    public void SkipCurrentTask() //Currently skips by auto-completing the task.  We should probably add a value that lets the user know the task has been 
    {
        if (currentTask != null && currentTask.Crit == 1)
        {
            currentTask.CompleteTask();
        }
        else
        {
            string taskTextString = "Task number " + currentTask.TaskID + " can not be skipped.\nPress the start button to begin the task.";
            textUpdateManager.TriggerTextUpdate(taskTextString);
        }
    }

    public void StartCurrentTask()
    {
        if (currentTask != null && !currentTask.IsComplete)
        {
            currentTask.StartTask();
        }
        else
        {
            string taskTextString = "Task " + currentTask.TaskID + " is already complete.";
            textUpdateManager.TriggerTextUpdate(taskTextString);
        }
    }

    public void TaskCompletionUpdate()
    {
        string taskTextString = "Current Task: " + currentTask.TaskID + "\nIs Complete: " + currentTask.IsComplete;
        textUpdateManager.TriggerTextUpdate(taskTextString);
        if (CurrentMode != "Sandbox")
        {
            NextTask();
        }
    }

    private void TextUpdateCurrentTask()
    {
        CurrentTaskTextUpdate currentTaskTextUpdate = new CurrentTaskTextUpdate(currentTask.TaskName, currentTask.TaskID, currentTask.IsActive, currentTask.IsComplete, CurrentMode);
        string taskUpdate = currentTaskTextUpdate.ToString();
        textUpdateManager.TriggerTextUpdate(taskUpdate);
    }
}

