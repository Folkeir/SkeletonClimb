using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject victory;
    void Start()
    {
        
    }

  

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    public void ShowVictory()
    {
        victory.SetActive(true);
    }
}
