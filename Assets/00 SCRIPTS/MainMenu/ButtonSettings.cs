using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSettings : MonoBehaviour
{
    [SerializeField] GameObject menuPanel,settingPanel;
    [SerializeField] Button backButton;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Settings);
    }
    void Settings()
    {
        menuPanel.SetActive(!gameObject.activeInHierarchy);
        settingPanel.SetActive(!gameObject.activeInHierarchy);
        if (!settingPanel.gameObject.activeInHierarchy)
            return;
        if (!backButton.gameObject.activeInHierarchy)
        {
            backButton.gameObject.SetActive(true);
            return;
        }
        backButton.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            settingPanel.SetActive(false);
            backButton.gameObject.SetActive(false);
            menuPanel.SetActive(true);
        });
    }
}
