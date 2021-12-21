using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider healthBar;
    public Slider xpBar;
    public GameObject mapPanel;
    public GameObject attributesPanel; 

    /* kad player primi štetu, oduzmi tu količinu od playerHealtha i umanji vrednost HP bara. */
    /* ako je vrednost bara nula, pokreni proceduru za prikazivanje hub panela*/
    public void changeHealthBarValue()
    {
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        healthBar.maxValue = (int)player_script.GetPlayerMaxHealth();
        healthBar.value = player_script.GetPlayerHealth();
        if (healthBar.value == 0)
        {
            Invoke("LoadHubPanel", 0.3f);
        }
    }

    /* kad monster umre, dodaj njegovu XP vrednost XPu playera, */
    /* i dodaj tu vrednost XP baru */
    public void ChangeXpBarValue()
    {
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        xpBar.maxValue = player_script.GetPlayerXPLimit();
        xpBar.value = player_script.GetPlayerXP();
    }
    
    /* kad player izgubi sve helte, deaktiviraj trenutni screen, */
    /* i aktiviraj mapPanel ako nije dobio level, ili attributePanel ako jeste */
    public void LoadHubPanel()
    {
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        DeactivateThisLevelAndActivateHub();
        ActivateAllMonsters();
        ResetMaxHealth();
        if (player_script.GetPlayerAttributes() > 0)
        {
            mapPanel.SetActive(false);
            attributesPanel.SetActive(true);
            ActivateAttributeButtons(true);
        }
        else
        {
            attributesPanel.SetActive(false);
            mapPanel.SetActive(true);
            ActivateAttributeButtons(false);
        }
    }

    /* pronadji topPanel objekat, u njemu prvo nadji aktivan level panel, pa onda aktivnu scenu, */
    /* deaktiviraj tu scenu i aktiviraj hubPanel */
    private void DeactivateThisLevelAndActivateHub()
    {
        GameObject topPanels = GameObject.Find("TopPanels");
        for (int i = 0; i < topPanels.transform.childCount; i++)
        {
            if(topPanels.transform.GetChild(i).gameObject.activeSelf)
            {
                //first, find the active level panel
                GameObject firstActiveLevelPanel = topPanels.transform.GetChild(i).gameObject;
                for (int j = 0; j < firstActiveLevelPanel.transform.childCount; j++)
                {  
                    //then, find the first active child within that level
                    if (firstActiveLevelPanel.transform.GetChild(j).gameObject.activeSelf)
                    {
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

    private void ResetMaxHealth()
    {
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        player_script.SetPlayerHealth((int)player_script.GetPlayerMaxHealth());
    }
}
