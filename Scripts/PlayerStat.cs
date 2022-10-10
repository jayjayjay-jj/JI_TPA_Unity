using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerStat : MonoBehaviour
{
    public static int minXP = 0;

    public static int maxHP = 1000;
    public static int maxXP = 100;

    public int currentHP;
    public int currentXP;
    public static int level = 1;

    public Slider healthBar;
    public Slider levelBar;
    public TMP_Text hp;
    public TMP_Text xp;

    public static bool Death;

    // Start is called before the first frame update   
    void Start()
    {
        currentHP = maxHP;
        currentXP = minXP;

        Death = false;

        healthBar.maxValue = maxHP;
        levelBar.maxValue = maxXP;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            damagetoHP(100);
        }
        */

        if(Input.GetKeyDown(KeyCode.R))
        {
            levelPointUp(10);
        }

        healthBar.value = currentHP;
        hp.SetText(healthBar.value + "/" + healthBar.maxValue);

        levelBar.value = currentXP;
        xp.SetText(levelBar.value + "/" + levelBar.maxValue);

        if (currentHP <= 0)
        {
            Death = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    public void damagetoHP(int damage)
    {
        currentHP -= damage;
    }

    public void levelPointUp(int point)
    { 

        if (currentXP < maxXP)
        {
            currentXP += point;
        } else if(currentXP >= maxXP)
        {
            level++;
            Debug.Log(level);
            currentXP = currentXP - maxXP;
        }

    }
}