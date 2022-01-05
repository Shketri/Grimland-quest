using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public double playerMaxHealth;
    public double playerHealth;
    public double playerDamage;
    public double playerArmor;
    public int playerProgress;
    public string playerProgressText;
    public double playerXP;
    public int playerLevelCount;
    public double playerXPLimit;
    public int playerAttributes;

    public SaveData(PlayerScript playerScript)
    {
        playerMaxHealth = playerScript.GetPlayerMaxHealth();
        playerHealth = playerScript.GetPlayerHealth();
        playerDamage = playerScript.GetPlayerDamage();
        playerArmor = playerScript.GetPlayerArmor();
        playerProgress = playerScript.GetPlayerProgress();
        playerProgressText = playerScript.playerProgressText;
        playerXP = playerScript.GetPlayerXP();
        playerLevelCount = playerScript.GetPlayerLevelCount();
        playerXPLimit = playerScript.GetPlayerXPLimit();
        playerAttributes = playerScript.GetPlayerAttributes();
    }
}
