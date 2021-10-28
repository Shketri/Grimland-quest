
using UnityEngine;
using TMPro;

public class MonsterScript : MonoBehaviour
{
    public int monsterHealth;
    public int monsterDamage;
    public TextMeshProUGUI healthText;
    public GameObject playerScript;
    public GameObject monster;
    public GameObject panel;
    public string name;
    public AudioSource audioSource;

    public void RecieveDamage()
    {
        audioSource.Play();
        PlayerScript player_script = playerScript.GetComponent<PlayerScript>();
        PanelScript panelScript = panel.GetComponent<PanelScript>();
        panelScript.Invoke("AttackWithAllMonsters", 0.7f);
        if (player_script.GetPlayerDamage() < monsterHealth)
        {
            Debug.Log(name + " recieved damage!");
            monsterHealth = monsterHealth - player_script.GetPlayerDamage();
            healthText.SetText(monsterHealth.ToString());
            //Invoke("DealDamage", 1f);
        }
        else
        {
            Invoke("Destroyed", 0.1f);
        }
    }

    public void DealDamage()
    {
        Vector3 temp = new Vector3(0,-25f,0);
        monster.transform.position += temp;
        Invoke("GoBack", 0.3f);
        PlayerScript player_script = playerScript.GetComponent<PlayerScript>();
        int playerHealth = player_script.GetPlayerHealth();
        player_script.SetPlayerHealth(playerHealth - monsterDamage);
        Debug.Log("" + name + " dealt damage! ouch!");
    }

    private void Destroyed()
    {
        //PanelScript panelScript = panel.GetComponent<PanelScript>();
        Debug.Log("Destroyed " + name + "!");
        //panelScript.LoadNextPanel();
        Destroy(monster);
    }

    private void GoBack()
    {
        Vector3 temp = new Vector3(0,25f,0);
        monster.transform.position += temp;
    }

}
