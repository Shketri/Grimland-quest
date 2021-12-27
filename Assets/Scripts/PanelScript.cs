using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    private GameObject mapPanel;
    private GameObject attributesPanel;

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
                MonsterScript monsterScript = gameObject.transform.GetChild(i).GetChild(1).GetComponent<MonsterScript>();
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
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        player_script.SetPlayerProgress(gameObject.transform.parent.gameObject.transform.parent.gameObject);
        GameObject topPanels = GameObject.Find("TopPanels");
        mapPanel = topPanels.transform.GetChild(0).transform.GetChild(0).gameObject;
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
        if (data != null) {
            playButton.transform.GetChild(1).gameObject.SetActive(true);
            playButton.transform.GetChild(2).gameObject.SetActive(true);
            Text progressText = playButton.transform.GetChild(0).gameObject.GetComponent<Text>();
            progressText.text = playerProgressText(data.playerProgress);
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

    private string playerProgressText(int playerProgress)
    {
        switch (playerProgress)
        {
            case 0:
                return "Misty Spring Woods"; 
            case 1:
                return "Duskwood";
            case 2:
                return "Mountains";
            case 3:
                return "Graveyard";
            case 4:
                return "Clay labyrinth";
            case 5:
                return "Puppeteer's palace";
            case 6:
                return "Ivory gates";
            case 7:
                return "Underground";
            case 8:
                return "Grimland";
        }
        return "New game";
    }

    public void DeleteSave(int saveNumber)
    {
        SaveScript.DeleteSave(saveNumber);
    }

    public void SaveGame()
    {
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        SaveScript.SavePlayer(player_script, player_script.saveNumber);
    }
}
