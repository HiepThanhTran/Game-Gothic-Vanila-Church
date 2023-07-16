using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] GameObject angelPrefab, ghoulPrefab, wizardPrefab;
    [SerializeField] List<Transform>angelPoints,ghoulPoints,wizardPoints = new List<Transform>();
    void Start()
    {
        foreach(var ds in angelPoints)
        {
            GameObject angel = Instantiate(angelPrefab, ds.position, Quaternion.identity);
            angel.SetActive(true);
        }
        foreach (var ds in ghoulPoints)
        {
            GameObject ghoul = Instantiate(ghoulPrefab, ds.position, Quaternion.identity);
            ghoul.SetActive(true);
        }
        foreach (var ds in wizardPoints)
        {
            GameObject wizard = Instantiate(wizardPrefab, ds.position, Quaternion.identity);
            wizard.SetActive(true);
        }
    }
}
