using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CustomTargetHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToEnableOnFound = new();
    [SerializeField] private List<GameObject> objectsToDisableOnLost = new();

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
        var tracked = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;

        if (tracked && !hasBeenDetected)
        {
            hasBeenDetected = true;
            OnTargetFound();
        }
        else if (!tracked && hasBeenDetected)
        {
            hasBeenDetected = false;
            OnTargetLost();
        }
    }

    private void OnTargetFound()
    {
        foreach (var obj in objectsToEnableOnFound)
        {
            if (obj) obj.SetActive(true);
        }
    }

    private void OnTargetLost()
    {
        foreach (var obj in objectsToDisableOnLost)
        {
            if (obj) obj.SetActive(false);
        }
    }
}