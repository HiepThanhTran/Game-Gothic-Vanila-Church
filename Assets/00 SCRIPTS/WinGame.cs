using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinGame : MonoBehaviour
{
    [SerializeField] GameObject panelEnter;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            panelEnter.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        } 
    }

}
