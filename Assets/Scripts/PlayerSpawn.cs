
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{

    int playerIndex = 0;
    [SerializeField] PlayerInputManager playerInputManager;
    [SerializeField] GameObject[] spawnLocations;
    public List<GameObject> playerGameObject;
    [SerializeField] CameraScript cameraScript;
    [SerializeField] GameManager gameManager;
    [SerializeField] UIManager uiManager;
    public int playeramount = 0;

    private void Start()
    {
       
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerJoined;

    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        
        cameraScript.PlayerSelect();
        Debug.Log("player joined");
        playerGameObject.Add(playerInput.gameObject);
        playerGameObject[playerIndex].transform.position = spawnLocations[playerIndex].transform.position;
        InputMan joiningInputManScript = playerInput.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<InputMan>();
        joiningInputManScript.assignPlayerColor(playerIndex);
        uiManager.EnablePlayerUI(playerIndex);
        joiningInputManScript.AssignPlayerUI(uiManager.GetPlayerUI(playerIndex));
        playerIndex++;
        playeramount++;
        // playerGameObject[playerIndex] = playerInput.gameObject;

    }

    public void PlayerDeath(GameObject deadPlayer)
    {
        Debug.Log("deadpleyaer : " + deadPlayer);
        foreach (GameObject player in playerGameObject)
        {
            if (player.GetComponent<PlayerInput>() == deadPlayer.transform.root.gameObject.GetComponent<PlayerInput>())
            {
                playeramount--;
                playerGameObject.Remove(player);

                if (playeramount <= 0)
                {
                    gameManager.GameOver();
                }
                //deadPlayer.transform.root.gameObject


                break;
            }
        }
    }

}
