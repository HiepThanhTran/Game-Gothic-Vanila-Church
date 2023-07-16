using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : Singleton<PlayerHP>,IHp
{
    float currentHp;
    public float CurrentHp { get => currentHp; set => currentHp = value; }
    public float HP()
    {
        return this.currentHp;
    }
}