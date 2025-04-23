using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float moveSpeed = 0.5f;       // Speed of the movement
    public float moveDistance = 1.5f;    // How far the cloud moves left/right

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
        moveSpeed += Random.Range(-0.2f, 0.2f);
        moveDistance += Random.Range(-0.5f, 0.5f);
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
transform.position = startPos + new Vector3(0f, 0f, offset);
    }
}