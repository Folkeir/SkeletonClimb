using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLine : MonoBehaviour
{
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
    }

    public void SetLinePositions(int index,Vector3 position)
    {
        lineRenderer.SetPosition(index,position);
    }
  
}
