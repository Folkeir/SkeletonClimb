
using UnityEngine;
using TMPro;

public class PlayerText : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private PlayerPickUp playerPickup;

    private void Start()
    {
        textMesh.enabled = false;
    }

    public void UpdateCoinText()
    {
        textMesh.enabled = true;
        textMesh.text = "Coins: " + playerPickup.Coins;
    }
    private void Update()
    {
        textMesh.transform.position = transform.position + Vector3.up * 1.4f;
    }
}