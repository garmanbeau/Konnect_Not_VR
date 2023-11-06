using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskImplementationBase : MonoBehaviour
{
    public virtual void StartTask()
    {
        //Task specific logic to execute when a task starts.
    }

    public virtual void StopTask()
    {
        //Task specific logic to execute when a task stops without completing.
    }

}
