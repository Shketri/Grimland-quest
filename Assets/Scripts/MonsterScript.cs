
using System;
using UnityEngine;
using TMPro;

public class MonsterScript : MonoBehaviour
{
    public int monsterHealth;
    public int monsterDamage;
    public int monsterXP;
    public TextMeshProUGUI healthText;
    public GameObject monster;
    public AudioSource audioSource;

    public void RecieveDamage()
    {
        audioSource.Play();
        AttackAnimation();
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();


        GameObject panel = gameObject.transform.parent.transform.parent.gameObject;
        PanelScript panelScript = panel.GetComponent<PanelScript>();
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
            startAnimation();
            GameObject player = GameObject.Find("PlayerScriptObject");
            PlayerScript player_script = player.GetComponent<PlayerScript>();
            int playerHealth = player_script.GetPlayerHealth();
            int monsterDamageFinal = monsterDamage - (int) player_script.GetPlayerArmor() / 100;
            player_script.SetPlayerHealth(playerHealth - monsterDamageFinal);
            //Debug.Log("Monster original damage is " + monsterDamage + ", and damage reduced by armor is " +
              //        monsterDamageFinal);
        }
    }

    private void Destroyed()
    {
        giveXP();
        //Destroy(monster);
        monster.SetActive(false);
    }

    private void giveXP()
    {
        GameObject player = GameObject.Find("PlayerScriptObject");
        PlayerScript player_script = player.GetComponent<PlayerScript>();
        player_script.SetPlayerXP(monsterXP);
    }

    private void startAnimation()
    {
        Vector3 temp = new Vector3(0,-25f,0);
        monster.transform.position += temp;
        Invoke("GoBack", 0.3f);
    }
    
    private void GoBack()
    {
        Vector3 temp = new Vector3(0,25f,0);
        monster.transform.position += temp;
    }

    private void AttackAnimation()
    {
        try
        {
            monster.transform.GetChild(2).gameObject.SetActive(true);
        } catch (Exception) {
            print("AttackAnimationError");
        }  

        Invoke("AttackAnimationHide", 0.3f);
    }
    
    private void AttackAnimationHide()
    {
        monster.transform.GetChild(2).gameObject.SetActive(false);
    }

}
