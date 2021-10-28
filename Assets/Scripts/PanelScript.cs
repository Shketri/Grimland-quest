using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    public GameObject thisPanel;
    public GameObject nextPanel;

    public void LoadNextPanel()
    {
        thisPanel.SetActive(false);
        nextPanel.SetActive(true);
    }

    public void AttackWithAllMonsters()
    {
        if (thisPanel.transform.childCount > 0)
        {
            foreach(Transform child in transform)
            {
                MonsterScript monsterScript =  child.GetChild(1).GetComponent<MonsterScript>();
                monsterScript.DealDamage();
            }
        }
        else
        {
            LoadNextPanel();
        }
    }
}
