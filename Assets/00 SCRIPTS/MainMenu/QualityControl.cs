using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QualityControl : MonoBehaviour
{
    [SerializeField]TMP_Dropdown qualityDropdown;
    List<string> qualityList = new List<string>();
    int currentQualityIndex;
    List<string> options = new List<string>();
    void Start()
    {
        qualityDropdown.ClearOptions();
        for (int i = 0; i < QualitySettings.names.Length; i++)
        {
            string qualityOption = QualitySettings.names[i];
            qualityList.Add(qualityOption);
            options.Add(qualityOption);
        }
        qualityDropdown.AddOptions(options);
        currentQualityIndex = QualitySettings.GetQualityLevel();
        qualityDropdown.value = currentQualityIndex;
        qualityDropdown.RefreshShownValue();
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
