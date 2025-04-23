using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CustomTargetHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToEnableOnFound = new();
    [SerializeField] private List<GameObject> objectsToDisableOnFound = new(); 
    [SerializeField] private List<GameObject> objectsToDisableOnLost = new();
    [SerializeField] private List<GameObject> objectsToEnableOnLost = new();     // NEW


    private ObserverBehaviour observer;
    private bool hasBeenDetected = false;

    private void Awake()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool isTracked = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;

        if (isTracked && !hasBeenDetected)
        {
            hasBeenDetected = true;
            OnTrackingStart();
        }
        else if (!isTracked && hasBeenDetected)
        {
            hasBeenDetected = false;
            OnTrackingStop();
        }
    }

    private void OnTrackingStart()
    {
        foreach (var obj in objectsToEnableOnFound)
        {
            if (obj) obj.SetActive(true);
        }

        foreach (var obj in objectsToDisableOnFound)
        {
            if (obj) obj.SetActive(false);
        }
    }

    private void OnTrackingStop()
    {
        foreach (var obj in objectsToDisableOnLost)
        {
            if (obj) obj.SetActive(false);
        }

        foreach (var obj in objectsToEnableOnLost)
            if (obj) obj.SetActive(true);
    }
}