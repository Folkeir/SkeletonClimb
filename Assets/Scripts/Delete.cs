using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour

{
    public float maxDistanceFromOrigin = 10000f;
    public float maxWorldScaleMagnitude = 1000f;

    void Start()
    {
        int deletedCount = 0;

        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            // Skip inactive and prefab instances
            if (!obj.activeInHierarchy || obj.scene.name == null)
                continue;

            Transform t = obj.transform;

            // Check distance
            bool tooFar = t.position.magnitude > maxDistanceFromOrigin;

            // Check scale
            bool tooLarge = t.lossyScale.magnitude > maxWorldScaleMagnitude;

            if (tooFar || tooLarge)
            {
                Debug.LogWarning($"Deleting '{obj.name}' - Too far or too large. Pos: {t.position}, Scale: {t.lossyScale}");
                Destroy(obj);
                deletedCount++;
            }
        }

        Debug.Log($"Cleanup complete. Deleted {deletedCount} objects.");
    }
}
