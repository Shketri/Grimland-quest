using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private int playerMaxHealth = 100;
    private int playerHealth = 100;
    private int playerDamage = 8;
    public GameObject healthBar;
    public AudioSource audioSource;

    public int GetPlayerMaxHealth()
    {
        return playerMaxHealth;
    }

    public void SetPlayerMaxHealth(int value)
    {
        playerMaxHealth = value;
    }
    
    public int GetPlayerDamage()
    {
        return playerDamage;
    }

    public void SetPlayerDamage(int value)
    {
        playerDamage = value;
    }
    
    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void SetPlayerHealth(int value)
    {
        audioSource.Play();
        playerHealth = value;
        if (value < 1)
        {
            // SceneManager.LoadScene(0);
        }
        HealthBarScript healthBar_script = healthBar.GetComponent<HealthBarScript>();
        healthBar_script.ChangeValue();
    }
}