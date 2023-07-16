using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHpBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Transform hpBarData;
    void FixedUpdate()
    {
        UpdateHpBar();
    }
    protected virtual void UpdateHpBar()
    {
        if (slider == null)
            return;
        PlayerHP hp = PlayerHP.Instant;
        if (hp == null)
            return;
        this.slider.value = hp.HP();
    }
}
