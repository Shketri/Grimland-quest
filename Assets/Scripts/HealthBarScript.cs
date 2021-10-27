using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
 
    public GameObject player;
    public Slider healthBar;
    
    public void ChangeValue()
    {
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        healthBar.maxValue = player_script.GetPlayerMaxHealth();
        healthBar.value = player_script.GetPlayerHealth();
    }
    
}
