using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public void LoadNextPanel()
    {
        gameObject.SetActive(false);
        GameObject thisLevel = gameObject.transform.parent.gameObject;
        GameObject nextPanel = null;
        for (int i = 0; i < thisLevel.transform.childCount; i++)
        {
            if (thisLevel.transform.GetChild(i).gameObject == gameObject)
            {
                nextPanel = thisLevel.transform.GetChild(i + 1).gameObject;
                break;
            }
        }

        nextPanel.SetActive(true);
    }

    public void AttackWithAllMonsters()
    {
        LockAllMonsters(true);
        int activeMonsters = 0;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf)
            {
                MonsterScript monsterScript =
                    gameObject.transform.GetChild(i).GetChild(1).GetComponent<MonsterScript>();
                monsterScript.DealDamage();
                activeMonsters += 1;
            }
        }

        if (activeMonsters < 1)
        {
            LoadNextPanel();
        }
    }

    public void setMapStatus()
    {
        PlayerScript player_script = GameObject.Find("PlayerScriptObject").GetComponent<PlayerScript>();
        player_script.SetPlayerProgress(gameObject.transform.parent.gameObject.transform.parent.gameObject);
        GameObject mapPanel = GameObject.Find("TopPanels").transform.GetChild(0).transform.GetChild(0).gameObject;
        MapScript mapScript = mapPanel.GetComponent<MapScript>();
        mapScript.SetupMapStatus();
    }

    public void LockAllMonsters(bool value)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<Button>().interactable = value;
        }
    }

    public void SetSaveButtonStatus()
    {
        GameObject playButton1 = GameObject.Find("PlayButton1");
        GameObject playButton2 = GameObject.Find("PlayButton2");
        GameObject playButton3 = GameObject.Find("PlayButton3");

        SaveData data1 = SaveScript.LoadPlayer(1);
        SaveData data2 = SaveScript.LoadPlayer(2);
        SaveData data3 = SaveScript.LoadPlayer(3);

        PrepareSaveButton(playButton1, data1);
        PrepareSaveButton(playButton2, data2);
        PrepareSaveButton(playButton3, data3);
    }

    private void PrepareSaveButton(GameObject playButton, SaveData data)
    {
        if (data != null)
        {
            playButton.transform.GetChild(1).gameObject.SetActive(true);
            playButton.transform.GetChild(2).gameObject.SetActive(true);
            Text progressText = playButton.transform.GetChild(0).gameObject.GetComponent<Text>();
            progressText.text = data.playerProgressText;
            Text levelText = playButton.transform.GetChild(1).gameObject.GetComponent<Text>();
            levelText.text = "Player level: " + data.playerLevelCount;
        }
        else
        {
            playButton.transform.GetChild(1).gameObject.SetActive(false);
            playButton.transform.GetChild(2).gameObject.SetActive(false);
            Text progressText = playButton.transform.GetChild(0).gameObject.GetComponent<Text>();
            progressText.text = "New game";
        }
    }

    public void LoadHubPanel()
    {
        PlayerScript player_script = GameObject.Find("PlayerScriptObject").GetComponent<PlayerScript>();
        GameObject mapPanel = GameObject.Find("TopPanels").transform.GetChild(0).transform.GetChild(0).gameObject;
        GameObject attributesPanel = GameObject.Find("TopPanels").transform.GetChild(0).transform.GetChild(1).gameObject;
        DeactivateThisLevelAndActivateHub();
        ActivateAllMonsters();
        player_script.SetPlayerHealth((int) player_script.GetPlayerMaxHealth());
        if (player_script.GetPlayerAttributes() > 0)
        {
            mapPanel.SetActive(false);
            attributesPanel.SetActive(true);
            ActivateAttributeButtons(true);
            player_script.ChangeAttributesText();
        }
        else
        {
            attributesPanel.SetActive(false);
            mapPanel.SetActive(true);
            ActivateAttributeButtons(false);
        }

        SaveScript.SavePlayer(player_script, player_script.saveNumber);
    }

    private void DeactivateThisLevelAndActivateHub()
    {
        GameObject topPanels = GameObject.Find("TopPanels");
        for (int i = 0; i < topPanels.transform.childCount; i++)
        {
            if (topPanels.transform.GetChild(i).gameObject.activeSelf)
            {
                //first, find the active level panel
                GameObject firstActiveLevelPanel = topPanels.transform.GetChild(i).gameObject;
                for (int j = 0; j < firstActiveLevelPanel.transform.childCount; j++)
                {
                    //then, find the first active child within that level
                    if (firstActiveLevelPanel.transform.GetChild(j).gameObject.activeSelf)
                    {
                        //deactivate that scene
                        firstActiveLevelPanel.transform.GetChild(j).gameObject.SetActive(false);
                        // activate first topPanel child (that is the hub panel)
                        topPanels.transform.GetChild(0).gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }
    }

    private void ActivateAttributeButtons(bool value)
    {
        GameObject topPanels = GameObject.Find("TopPanels");
        topPanels.transform.GetChild(0).transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(value);
    }

    /* go trough all level panels, and if there are inactive monsters, activate them */
    private void ActivateAllMonsters()
    {
        GameObject topPanels = GameObject.Find("TopPanels");
        for (int i = 1; i < topPanels.transform.childCount; i++)
        {
            GameObject levelPanel = topPanels.transform.GetChild(i).gameObject;
            for (int j = 0; j < levelPanel.transform.childCount; j++)
            {
                GameObject levelPanelScene = levelPanel.transform.GetChild(j).gameObject;
                for (int k = 0; k < levelPanelScene.transform.childCount; k++)
                {
                    GameObject monster = levelPanelScene.transform.GetChild(k).gameObject;
                    if (!monster.gameObject.activeSelf)
                    {
                        monster.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    public void DeleteSave(int saveNumber)
    {
        SaveScript.DeleteSave(saveNumber);
    }

    public void SaveGame()
    {
        PlayerScript player_script = GameObject.Find("PlayerScriptObject").GetComponent<PlayerScript>();
        SaveScript.SavePlayer(player_script, player_script.saveNumber);
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
    
}
