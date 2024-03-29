using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class sc_SceneManager : MonoBehaviour
{
    // M�thode pour charger la sc�ne "Jouer"
    public void ChargerSceneJouer()
    {
        SceneManager.LoadScene("Map Ld");
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // M�thode pour charger la sc�ne "Controls"
    public void ChargerSceneControls()
    {
        SceneManager.LoadScene("Controls");
        Time.timeScale = 1.0f;
    }

    // M�thode pour charger la sc�ne "Controls"
    public void ChargerSceneGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
        Time.timeScale = 1.0f;
    }

    // M�thode pour quitter l'application
    public void QuitterApplication()
    {
        Debug.Log("Application quitt�e."); // Message pour v�rifier dans l'�diteur Unity
        Application.Quit();
    }
}
