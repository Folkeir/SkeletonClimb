using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLine : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] Gradient[] gradients;

    // Start is called before the first frame update
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (lineRenderer == null)
        {
            Debug.LogError("No LineRenderer found on: " + gameObject.name, this);
            return;
        }

        lineRenderer.useWorldSpace = true;
    }

    public void SetLinePositions(int index,Vector3 position)
    {
        lineRenderer.SetPosition(index,position);
    }

    public void SetColor(int playerIndex)
    {
        switch (playerIndex)
        {
            case 0:
                lineRenderer.colorGradient = gradients[0];
                break;
            case 1:
                lineRenderer.colorGradient = gradients[1];
                break;
            case 2:
                lineRenderer.colorGradient = gradients[2];
                break;
            case 3:
                lineRenderer.colorGradient = gradients[3];
                break;

        }

    }
    public void SetAlpha(float amount)
    {

        lineRenderer.material.SetFloat("_aimAlpha", amount);
    }
  
}
