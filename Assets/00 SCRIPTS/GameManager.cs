using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GAMESTATE gameState;
    public GAMESTATE GameState { get => gameState; set => gameState = value; }
    void Start()
    {
        PlayButton play = new PlayButton();
        play.playButton();
    }
    void Update()
    { 
        WinGame();
        LoseGame();
    }
    public void WinGame()
    {
        if (gameState != GAMESTATE.Win)
            return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoseGame()
    {
        if (gameState != GAMESTATE.Over)
            return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
