using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class sc_SceneManager : MonoBehaviour
{
    // M�thode pour charger la sc�ne "Jouer"
    public void ChargerSceneJouer()
    {
        SceneManager.LoadScene("Game");
    }

    // M�thode pour charger la sc�ne "Controls"
    public void ChargerSceneControls()
    {
        SceneManager.LoadScene("Controls");
    }

    // M�thode pour quitter l'application
    public void QuitterApplication()
    {
        Debug.Log("Application quitt�e."); // Message pour v�rifier dans l'�diteur Unity
        Application.Quit();
    }
}
