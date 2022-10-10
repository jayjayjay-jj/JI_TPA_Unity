using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;
    public TMP_Text level;

    public void setMinXP(int xp)
    {
        slider.minValue = xp;
        slider.value = xp;
    }

    public void setPlayerXP(int xp)
    {
        slider.value = xp;
    }

    public void setTextXP()
    {
        text.SetText(slider.value + "/" + slider.maxValue);
    }

    public void setLevel()
    {
        Debug.Log(level);
        level.SetText("Level" + PlayerStat.level);
    }
}
