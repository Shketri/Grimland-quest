using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private double playerMaxHealth = 1000000;
    private double playerHealth = 1000000;
    private double playerDamage = 80000;
    private double playerArmor = 100;
    private int playerProgress = 0;
    private double playerXP = 0;
    private int playerLevelCount = 1;
    private double playerXPLimit = 100;
    private int playerAttributes = 0;
    public string playerProgressText = "Spring Woods";
    public GameObject healthBar;
    public AudioSource audioSource;
    public int saveNumber = 1;

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
    
    public double GetPlayerHealth()
    {
        return playerHealth;
    }

    public void SetPlayerHealth(double value)
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
        switch (level.name)
        {
            case "ForestTopPanel":
                playerProgress = 1;
                playerProgressText = "Duskwood";
                break;
            case "GloomTopPanel":
                playerProgress = 2;
                playerProgressText = "Mountains";
                break;
            case "MountainTopPanel":
                playerProgress = 3;
                playerProgressText = "Graveyard";
                break;
            case "GraveyardTopPanel":
                playerProgress = 4;
                playerProgressText = "Clay labyrinth";
                break;
            case "ClayLabyrinthTopPanel":
                playerProgress = 5;
                playerProgressText = "Puppeteer's palace";
                break;
            case "PuppeteersPalaceTopPanel":
                playerProgress = 6;
                playerProgressText = "Ivory gates";
                break;
            case "IvoryGatesTopPanel":
                playerProgress = 7;
                playerProgressText = "Underground";
                break;
            case "UndergroundTopPanel":
                playerProgress = 8;
                playerProgressText = "Grimland";
                break;
            case "GrimlandTopPanel":
                playerProgress = 9;
                break;
        }
    }
    
    public double GetPlayerXP()
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
        playerXPLimit = playerXPLimit * 1.5;
        playerAttributes = playerAttributes + 1;
        ShowLevelUpText();
    }
    
    public double GetPlayerXPLimit()
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
        ChangeAttributesText();
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

    public void ChangeAttributesText()
    {
        GameObject topPanels = GameObject.Find("TopPanels");
        GameObject attributesText = topPanels.transform.GetChild(0).transform.GetChild(1).transform.GetChild(2).gameObject;
        attributesText.GetComponent<Text>().text = "Points: "+ playerAttributes;
    }

    public void LoadPlayer(int number)
    {
        saveNumber = number;
        SaveData data = SaveScript.LoadPlayer(saveNumber);

        if(data != null) {
            playerMaxHealth = data.playerMaxHealth;
            playerHealth = data.playerHealth;
            playerDamage = data.playerDamage;
            playerArmor = data.playerArmor;
            playerProgress = data.playerProgress;
            playerProgressText = data.playerProgressText;
            playerXP = data.playerXP;
            playerLevelCount = data.playerLevelCount;
            playerXPLimit = data.playerXPLimit;
            playerAttributes = data.playerAttributes;
        }
    }
}