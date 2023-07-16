using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResolutionControl : MonoBehaviour
{
    [SerializeField] TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    List<Resolution> resolutionList = new List<Resolution>();
    float currentRefreshRate;
    int currentResolutionIndex;
    List<string>options = new List<string>();
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate; // tần số hz
        foreach (Resolution resolution in resolutions)
        {
            if(resolution.refreshRate == currentRefreshRate)
                resolutionList.Add(resolution);
        }

        for(int i = 0; i< resolutionList.Count; i++)
        {
            string resolutionOption = resolutionList[i].width + "x" 
                                      + resolutionList[i].height + " " 
                                      + resolutionList[i].refreshRate 
                                      + "Hz";
            options.Add(resolutionOption);
            if (resolutionList[i].width == Screen.width && resolutionList[i].height == Screen.height)
                currentResolutionIndex = i; 
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,true);
    }
}
