using UnityEngine;

public class MapScript : MonoBehaviour
{
    public GameObject mapPanel;
    private int playerProgress;
    
    public void SetupMapStatus()
    {
        PlayerScript player_script = GameObject.Find("PlayerScriptObject").GetComponent<PlayerScript>();
        playerProgress = player_script.GetPlayerProgress();
        if (playerProgress >= 1)
        {
            SetUpGloom();
        }
        if (playerProgress >= 2)
        {
            SetUpMountain();
        }
        if (playerProgress >= 3)
        {
            SetUpGraveyard();
        }
        if (playerProgress >= 4)
        {
            SetUpClayLabyrinth();
        }
        if (playerProgress >= 5)
        {
            SetUpPupeteersPalace();
        }
        if (playerProgress >= 6)
        {
            SetUpIvoryGates();
        }
        if (playerProgress >= 7)
        {
            SetUpUnderground();
        }
        if (playerProgress >= 8)
        {
            SetUpGrimland();
        }
    }

    private void SetUpGloom()
    {
            GameObject questionMarkGloom = mapPanel.transform.GetChild(0).transform.Find("QuestionButton1").gameObject;
            GameObject normalGloom = mapPanel.transform.GetChild(0).transform.Find("GloomMapButton").gameObject;
            questionMarkGloom.SetActive(false);
            normalGloom.SetActive(true);
    }

    private void SetUpMountain()
    {
        GameObject questionMarkMountain = mapPanel.transform.GetChild(0).transform.Find("QuestionButton2").gameObject;
        GameObject normalMountain = mapPanel.transform.GetChild(0).transform.Find("MountainMapButton").gameObject;
        questionMarkMountain.SetActive(false);
        normalMountain.SetActive(true);
    }

    private void SetUpGraveyard()
    {
        GameObject act1Button = mapPanel.transform.GetChild(3).transform.Find("Act1Button").gameObject;
        GameObject act2Button = mapPanel.transform.GetChild(3).transform.Find("Act2Button").gameObject;
        GameObject normalGraveyard = mapPanel.transform.GetChild(1).transform.Find("GraveyardMapButton").gameObject;
        normalGraveyard.SetActive(true);
        act1Button.SetActive(true);
        act2Button.SetActive(true);
        ShowAct2();
    }
    
    private void SetUpClayLabyrinth()
    {
        GameObject questionMarkClayLabyrinth = mapPanel.transform.GetChild(1).transform.Find("QuestionButton1").gameObject;
        GameObject normalClayLabyrinth = mapPanel.transform.GetChild(1).transform.Find("ClayLabyrinthMapButton").gameObject;
        questionMarkClayLabyrinth.SetActive(false);
        normalClayLabyrinth.SetActive(true);
    }
    
    private void SetUpPupeteersPalace()
    {
        GameObject questionMarkPalace = mapPanel.transform.GetChild(1).transform.Find("QuestionButton2").gameObject;
        GameObject normalPalace = mapPanel.transform.GetChild(1).transform.Find("PalaceMapButton").gameObject;
        questionMarkPalace.SetActive(false);
        normalPalace.SetActive(true);
    }
    
    private void SetUpIvoryGates()
    {
        GameObject act3Button = mapPanel.transform.GetChild(3).transform.Find("Act3Button").gameObject;
        GameObject normalIvoryGates = mapPanel.transform.GetChild(2).transform.Find("IvoryGatesMapButton").gameObject;
        normalIvoryGates.SetActive(true);
        act3Button.SetActive(true);
        ShowAct3();
    }
    
    private void SetUpUnderground()
    {
        GameObject questionMarkUnderground = mapPanel.transform.GetChild(2).transform.Find("QuestionButton1").gameObject;
        GameObject normalUnderground = mapPanel.transform.GetChild(2).transform.Find("UndergroundMapButton").gameObject;
        questionMarkUnderground.SetActive(false);
        normalUnderground.SetActive(true);
    }
    
    private void SetUpGrimland()
    {
        GameObject questionMarkGrimland= mapPanel.transform.GetChild(2).transform.Find("QuestionButton2").gameObject;
        GameObject normalGrimland = mapPanel.transform.GetChild(2).transform.Find("GrimlandMapButton").gameObject;
        questionMarkGrimland.SetActive(false);
        normalGrimland.SetActive(true);
    }

    private void ShowAct2()
    {
        mapPanel.transform.GetChild(0).gameObject.SetActive(false);
        mapPanel.transform.GetChild(1).gameObject.SetActive(true);
        mapPanel.transform.GetChild(2).gameObject.SetActive(false);
    }
    
    private void ShowAct3()
    {
        mapPanel.transform.GetChild(0).gameObject.SetActive(false);
        mapPanel.transform.GetChild(1).gameObject.SetActive(false);
        mapPanel.transform.GetChild(2).gameObject.SetActive(true);
    }
    
}
