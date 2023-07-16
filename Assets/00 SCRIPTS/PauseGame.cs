using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameManager.Instant.GameState = GAMESTATE.Pause;
    }
    public void Resume()
    {
        GameManager.Instant.GameState = GAMESTATE.Play;
        pauseMenu.SetActive(false);
        ActiveManager.Instant.SetActives();
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        Time.timeScale = 0;
    }
}
