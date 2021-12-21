using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   // public void AttackWithAllMonsters()
    //{
      //  if (gameObject.transform.childCount > 0)
        //{
          //  foreach (Transform child in transform)
            //{
              //  MonsterScript monsterScript = child.GetChild(1).GetComponent<MonsterScript>();
                //monsterScript.DealDamage();
            //}
        //}
        //else
       // {
        //    LoadNextPanel();
        //}
    //}

    public void AttackWithAllMonsters()
    {
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
        mapPanel = GameObject.Find("MapPanel");
        MapScript mapScript = mapPanel.GetComponent<MapScript>();
        mapScript.setupMapStatus();
    }
}
