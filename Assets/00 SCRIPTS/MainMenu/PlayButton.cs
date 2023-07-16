using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
    }
    public void playButton()
    {
        GameManager.Instant.GameState = GAMESTATE.Play;
        Time.timeScale = 1;
    }
}