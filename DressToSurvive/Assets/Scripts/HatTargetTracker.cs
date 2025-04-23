using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class HatTargetTracker : MonoBehaviour
{
    private int trackCount = 0;

    public void OnTargetFound()
    {
        trackCount++;
        Debug.Log($"Image Target tracked {trackCount} time(s).");
    }
}