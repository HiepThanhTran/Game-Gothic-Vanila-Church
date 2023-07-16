using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveManager : Singleton<ActiveManager>
{
    List<GameObject> objects = new List<GameObject>();
    public List<GameObject> Objects { get => objects; set => objects = value; }
    public void SetActives()
    {
        foreach (GameObject gameObject in objects)
        {
            if (!gameObject.active)
                gameObject.SetActive(true);
        }
    }
}
