using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private ChunkEntry[] chunks;

    private void Update()
    {
        UpdateChunks();
    }

    private void UpdateChunks()
    {
        float cameraY = cameraTransform.position.y;

        foreach (ChunkEntry chunk in chunks)
        {
            bool shouldBeActive =
                cameraY >= chunk.minY &&
                cameraY <= chunk.maxY;

            if (chunk.chunk.activeSelf != shouldBeActive)
            {
                chunk.chunk.SetActive(shouldBeActive);
            }
        }
    }
}