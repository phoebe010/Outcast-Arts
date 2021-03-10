using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public Slider healthBar;

    private float currentHealth = 100;


    public void Damages(float damage)
    {
        currentHealth -= damage;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        healthBar.value = currentHealth;

        if (healthBar.value <= healthBar.minValue)
        {
            //StartCoroutine(ExecuteAfterTime(2));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        //deathscript.FadeToBlack();
    }
}