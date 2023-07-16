using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] List<BackGround> bgs = new List<BackGround>();

    [SerializeField] float configSpeed , baseSpeed = 5;
    void Start()
    {
        for(int i=0;i<bgs.Count;i++)
        {
            bgs[i].Speed = i * configSpeed;
        }
    }
}
