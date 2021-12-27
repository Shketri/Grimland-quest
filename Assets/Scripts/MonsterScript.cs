using System;
using UnityEngine;
using TMPro;

public class MonsterScript : MonoBehaviour
{
    public double monsterHealth;
    public double monsterDamage;
    public int monsterXP;
    public TextMeshProUGUI healthText;
    public GameObject monster;
    public AudioSource audioSource;

    public void RecieveDamage()
    {
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        GameObject panel = gameObject.transform.parent.transform.parent.gameObject;
        PanelScript panelScript = panel.GetComponent<PanelScript>();
        
        panelScript.LockAllMonsters(false);
        audioSource.Play();
        AttackSpriteShow();
        
        panelScript.Invoke("AttackWithAllMonsters", 0.7f);
        if (player_script.GetPlayerDamage() < monsterHealth)
        {
            monsterHealth = monsterHealth - (int) player_script.GetPlayerDamage();
            healthText.SetText(monsterHealth.ToString());
        }
        else
        {
            Invoke("Destroyed", 0.1f);
        }
    }

    public void DealDamage()
    {
        if (monster.gameObject.activeSelf)
        {
            StartAnimation();
            GameObject player = GameObject.Find("PlayerScriptObject");
            PlayerScript player_script = player.GetComponent<PlayerScript>();
            double playerHealth = player_script.GetPlayerHealth();
            double monsterDamageFinal = monsterDamage - player_script.GetPlayerArmor() / 100 + 1;
            player_script.SetPlayerHealth(playerHealth - monsterDamageFinal);
            //Debug.Log("Monster original damage is " + monsterDamage + ", and damage reduced by armor is " +
              //      monsterDamageFinal);
        }
    }

    private void Destroyed()
    {
        GiveXP();
        monster.SetActive(false);
    }

    private void GiveXP()
    {
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        player_script.SetPlayerXP(monsterXP);
    }

    private void StartAnimation()
    {
        Vector3 temp = new Vector3(0,-25f,0);
        monster.transform.position += temp;
        Invoke("GoBackAnimation", 0.3f);
    }
    
    private void GoBackAnimation()
    {
        Vector3 temp = new Vector3(0,25f,0);
        monster.transform.position += temp;
    }

    private void AttackSpriteShow()
    {
        try
        {
            monster.transform.GetChild(2).gameObject.SetActive(true);
        } catch (Exception) {
            print("AttackAnimationError");
        }  

        Invoke("AttackSpriteHide", 0.3f);
    }
    
    private void AttackSpriteHide()
    {
        monster.transform.GetChild(2).gameObject.SetActive(false);
    }
}
