using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject victory;
    [SerializeField] private PlayerUI[] playerUI;
    [SerializeField] private GameObject pressToStartImage;
   // [SerializeField] private GameObject pressStartText;
   
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    public void ShowVictory()
    {
        victory.SetActive(true);
    }

    public void DisablePressStart()
    {
     //  pressStartText.SetActive(false);
    }

    public void EnablePlayerUI(int playerIndex)
    {
        playerUI[playerIndex].gameObject.SetActive(true);
        pressToStartImage.SetActive(false);
       // pressStartText.SetActive(true);

    }
    public PlayerUI GetPlayerUI(int playerIndex)
    {
        return playerUI[playerIndex];
    }
}
