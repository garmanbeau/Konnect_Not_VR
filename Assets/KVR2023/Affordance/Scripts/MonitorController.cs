using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MonitorController : MonoBehaviour
{
    [SerializeField] private TextUpdateManager textUpdateManager;
    private TextMeshPro textComponent; // Reference to a TMPUGUI component of a GameObject.

    private void Start() //Called via Unity Magic when an instance of the MonitorController class is instantiated.
    {
        textComponent = gameObject.GetComponent<TextMeshPro>(); //Assigning textComponent to the TMPUGUI component of the GameObject this script/class is attached to.
    }

    private void OnEnable() //Subscribe to the event when the monitor is enabled. Called via Unity Magic.
    {
        textUpdateManager.textUpdateEvent.AddListener(UpdateText);
    }

    private void OnDisable() //Unsubscribe from the event when the monitor is disabled. Called via Unity Magic.
    {
        textUpdateManager.textUpdateEvent.RemoveListener(UpdateText);
    }

    private void UpdateText(string newText) //Update the TMP component with the new text
    {
        textComponent.text = newText;
    }
}
