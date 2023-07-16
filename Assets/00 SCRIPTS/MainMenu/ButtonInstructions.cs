using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonInstructions : MonoBehaviour
{
    [SerializeField] GameObject menuPanel, instructionsPanel;
    [SerializeField] Button backButton;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Instructions);
    }

    void Instructions()
    {
        menuPanel.SetActive(!gameObject.activeInHierarchy);
        instructionsPanel.SetActive(!gameObject.activeInHierarchy);
        if (!instructionsPanel.gameObject.activeInHierarchy)
            return;
        if (!backButton.gameObject.activeInHierarchy)
        {
            backButton.gameObject.SetActive(true);
            return;
        }
        backButton.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            instructionsPanel.SetActive(false);
            backButton.gameObject.SetActive(false);
            menuPanel.SetActive(true);
        });
    }
}
