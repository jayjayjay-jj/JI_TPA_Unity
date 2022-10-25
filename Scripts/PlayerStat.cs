using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerStat : MonoBehaviour
{ 
    public static float minXP = 0;

    public static float maxHP = 1000;
    public static float maxXP = 100;

    public static float agility;
    public static float power;
    public static float strength;

    public float currentHP;
    public float currentXP;
    public static int level = 1;

    public Slider healthBar;
    public Slider levelBar;
    public TMP_Text hp;
    public TMP_Text xp;
    public TMP_Text levelValue;

    public static bool Death;
    public AudioSource playerDeath;
    public AudioSource levelUpSound;
    public Animator animator;
    public Animator playerAnimation;

    // Start is called before the first frame update   
    void Start()
    {
        currentHP = maxHP;
        currentXP = minXP;
        level = 1;
        levelUpSound.enabled = false;

        Death = false;
        playerDeath.enabled = false;

        healthBar.maxValue = maxHP;
        levelBar.maxValue = maxXP;

        agility = 1;
        power = 1;
        strength = 1;
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

        maxHP = 1000 + (strength * 100);

        if (currentHP <= 0 && Death == false)
        {
            Death = true;
            playerDeath.enabled = true;
            StartCoroutine(delay());
        }
    }
    IEnumerator delay()
    {
        animator.SetTrigger("Fade");
        playerAnimation.SetTrigger("isDeath");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            levelUpSound.enabled = true;
            Debug.Log(level);
            levelValue.SetText("Level " + level);
            currentXP = currentXP - maxXP;
            currentHP = maxHP;
        }

    }
}
