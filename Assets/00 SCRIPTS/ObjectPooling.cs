using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    Dictionary<GameObject, List<GameObject>> pools = new Dictionary<GameObject, List<GameObject>>();
    public GameObject GetObject(GameObject sample)
    {
        if (!pools.ContainsKey(sample))
            pools.Add(sample, new List<GameObject>());

        foreach (GameObject g in pools[sample])
        {
            if (g.activeSelf)
                continue;
            return g;
        }
        GameObject g2 = Instantiate(sample, this.transform.position, Quaternion.identity);
        pools[sample].Add(g2);
        return g2;
    }

    public GameObject GetObject(GameObject sample, Vector2 randPos)
    {
        if (!pools.ContainsKey(sample))
            pools.Add(sample, new List<GameObject>());

        foreach (GameObject g in pools[sample])
        {
            if (g.activeSelf)
                continue;
            return g;
        }
        GameObject g2 = Instantiate(sample, randPos, Quaternion.identity);
        pools[sample].Add(g2);
        return g2;
    }
}
