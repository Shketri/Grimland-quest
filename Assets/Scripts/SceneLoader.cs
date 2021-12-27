using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadGame(int saveNumber)
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerScriptObject");
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        playerScript.LoadPlayer(saveNumber);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
