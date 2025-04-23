// using System.Collections;
// using UnityEngine;
// using Vuforia;


// public class ImageTargetTracker : MonoBehaviour
// {
//     private ObserverBehaviour observer;

//     void Start()
//     {
//         observer = GetComponent<ObserverBehaviour>();
//         if (observer)
//         {
//             observer.OnTargetStatusChanged += OnTargetStatusChanged;
//         }
//     }

//     private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
//     {
//         if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
//         {
//             Debug.Log("Image Target Detected!");
//             // Your custom logic here, e.g., activate objects
//         }
//         else
//         {
//             Debug.Log("Image Target Lost.");
//             // Your custom logic here, e.g., deactivate objects
//         }
//     }
// }