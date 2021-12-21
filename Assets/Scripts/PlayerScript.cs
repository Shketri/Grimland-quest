using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private double playerMaxHealth = 100;
    private int playerHealth = 100;
    private double playerDamage = 80;
    private double playerArmor = 100;
    private int playerProgress = 0;
    private int playerXP = 0;
    private int playerLevelCount = 1;
    private int playerXPLimit = 100;
    private int playerAttributes = 0;
    public GameObject healthBar;
    public AudioSource audioSource;

    public double GetPlayerMaxHealth()
    {
        return playerMaxHealth;
    }

    public void SetPlayerMaxHealth(int value)
    {
        playerMaxHealth = playerMaxHealth * 1.1;
        HideAttributesButtons();
        Debug.Log("Player max health is "+playerMaxHealth+" now");
    }
    
    public double GetPlayerDamage()
    {
        return playerDamage;
    }

    public void SetPlayerDamage(int value)
    {
        playerDamage = playerDamage * 1.1;
        HideAttributesButtons();
        Debug.Log("Player damage is "+playerDamage+" now");
    }
    
    public double GetPlayerArmor()
    {
        return playerArmor;
    }

    public void SetPlayerArmor(int value)
    {
        playerArmor = playerArmor * 1.1;
        HideAttributesButtons();
        Debug.Log("Player armor is "+playerArmor+" now");
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
            
        }
        HealthBarScript healthBar_script = healthBar.GetComponent<HealthBarScript>();
        healthBar_script.changeHealthBarValue();
    }
    
    public int GetPlayerProgress()
    {
        return playerProgress;
    }
    
    public void SetPlayerProgress(GameObject level)
    {
        // if (level.name == "ForestTopPanel" && playerProgress == 0)
        if (level.name == "ForestTopPanel")
        {
            playerProgress = 1;
        }
        // if (level.name == "GloomTopPanel" && playerProgress == 1)
        if (level.name == "GloomTopPanel")
        {
            playerProgress = 2;
        }
        // if (level.name == "MountainTopPanel" && playerProgress == 2)
        if (level.name == "MountainTopPanel")
        {
            playerProgress = 3;
        }
    }
    
    public int GetPlayerXP()
    {
        return playerXP;
    }

    public void SetPlayerXP(int value)
    {
        playerXP = playerXP + value;
        if (playerXP > playerXPLimit)
        {
            levelUp();
            Debug.Log("Level up! Level:"+ playerLevelCount);
        }
        HealthBarScript healthBar_script = healthBar.GetComponent<HealthBarScript>();
        healthBar_script.ChangeXpBarValue();
    }

    private void levelUp()
    {
        playerXP = playerXP - playerXPLimit;
        playerLevelCount = playerLevelCount + 1;
        playerXPLimit = playerXPLimit * 2;
        playerAttributes = playerAttributes + 1;
        ShowLevelUpText();
    }
    
    public int GetPlayerXPLimit()
    {
        return playerXPLimit;
    }
    
    public void SetPlayerXPLimit(int value)
    {
        playerXPLimit = value;
    }
    
    public int GetPlayerLevelCount()
    {
        return playerLevelCount;
    }

    public void SetPlayerLevelCount(int value)
    {
        playerLevelCount = value;
    }
    
    public int GetPlayerAttributes()
    {
        return playerAttributes;
    }

    public void SetPlayerAttributes(int value)
    {
        playerAttributes = value;
    }

    public void HideAttributesButtons()
    {
        playerAttributes = playerAttributes - 1;
        if (playerAttributes < 1)
        {
            GameObject topPanels = GameObject.Find("TopPanels");
            topPanels.transform.GetChild(0).transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    private void ShowLevelUpText()
    {
        GameObject bottomPanel = GameObject.Find("BottomPanel");
        bottomPanel.transform.GetChild(2).gameObject.SetActive(true);
        Invoke("HideLevelUpText", 1f);
    }

    private void HideLevelUpText()
    {
        GameObject bottomPanel = GameObject.Find("BottomPanel");
        bottomPanel.transform.GetChild(2).gameObject.SetActive(false);
    }
}