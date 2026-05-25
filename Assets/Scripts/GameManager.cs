using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private UIManager uIManager;
    [SerializeField] private PlayerSpawn playerSpawn;
    [SerializeField] private MusicPlayer musicPlayer;
    public bool gameOver = false;
    public bool victory = false;
    public void GameOver()
    {
        gameOver = true;
        uIManager.ShowGameOver();
        musicPlayer.GameOver();
    }
    public void Victory()
    {
        victory = true;
        uIManager.ShowVictory();

    }
}
