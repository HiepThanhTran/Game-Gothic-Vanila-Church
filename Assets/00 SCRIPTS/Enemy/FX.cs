using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    [SerializeField] float timeDestruct;

    void OnEnable()
    {
        StartCoroutine(autoDestruc());
    }

    IEnumerator autoDestruc()
    {
        yield return new WaitForSeconds(timeDestruct);

        gameObject.SetActive(false);
    }
}
