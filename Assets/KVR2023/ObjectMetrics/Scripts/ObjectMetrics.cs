using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ObjectMetric : MonoBehaviour
{
    [field: SerializeField] public string ObjectName { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public List<int> AssociatedTaskIndexes { get; private set; }

    //private TestTaskManager testTaskManager;
    //[field: SerializeField]
    //private ObjectMetric self; 
    //private void Start()
    //{
    //    testTaskManager = GameObject.Find("TestTaskManager").GetComponent<TestTaskManager>();
    //    //Debug.Log(PrintObjectInformation()) ;
    //}


    //public void CallTestTaskManager() { 
    //    if(testTaskManager != null && testTaskManager.modeIsActive)
    //    {
    //        Debug.Log("In objectmetric, calling testtask");
    //        testTaskManager.IsGrabbedObjectPartOfCurrentTask(self);
    //    }
    //}

    public string PrintObjectInformation()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("The object name is: ");
        sb.Append(ObjectName);
        sb.Append(". Description: ");
        sb.Append(Description);
        sb.Append(" It is associated the tasks: ");
        foreach (var index in AssociatedTaskIndexes)
        {
            sb.Append(index.ToString() + "; ");
        }

        return sb.ToString();
    }
}
