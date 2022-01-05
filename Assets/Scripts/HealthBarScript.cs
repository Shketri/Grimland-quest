using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider healthBar;
    public Slider xpBar;

    public void changeHealthBarValue()
    {
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        healthBar.maxValue = (int)player_script.GetPlayerMaxHealth();
        healthBar.value = (int) player_script.GetPlayerHealth();
        if (healthBar.value == 0)
        {
            Invoke("panelScript.LoadHubPanel", 0.3f);
        }
    }

    public void ChangeXpBarValue()
    {
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        xpBar.maxValue = (int) player_script.GetPlayerXPLimit();
        xpBar.value = (int) player_script.GetPlayerXP();
    }
    
}
