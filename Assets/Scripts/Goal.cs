using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private bool hasBeenReached = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenReached)
            return;

        InputMan player = other.GetComponentInParent<InputMan>();

        if (player == null)
            return;

        hasBeenReached = true;

        PlayerText playerText = player.GetComponentInChildren<PlayerText>();

        if (playerText != null)
        {
            playerText.UpdateCoinText();
        }

        gameManager.Victory();
    }
}