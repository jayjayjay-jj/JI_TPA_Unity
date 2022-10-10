using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;
    public PlayerStat playerStat;

    public void setMaxHP(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void setPlayerHP(int hp) {
        slider.value = hp;
    }

    public void setTextHP()
    {
        text.SetText(slider.value + "/" + slider.maxValue);
    }
}
