using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookedRope : MonoBehaviour
{
   
    public Transform startPoint; // Assign in the inspector
    public Transform endPoint; // Assign in the inspector

    private LineRenderer lineRenderer;

    void Start()
    {
        // Get the LineRenderer component attached to this GameObject
        lineRenderer = GetComponent<LineRenderer>();

        // Set the initial positions of the line
        UpdateLinePositions();
    }

    void Update()
    {
        // Update the positions of the line
        UpdateLinePositions();
    }

    void UpdateLinePositions()
    {
        // Make sure both start and end points are assigned
        if (startPoint != null && endPoint != null && lineRenderer != null)
        {
            // Set the positions of the LineRenderer
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, endPoint.position);
        }
    }
}
