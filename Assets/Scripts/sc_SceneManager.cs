using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class sc_SceneManager : MonoBehaviour
{
    // Méthode pour charger la scène "Jouer"
    public void ChargerSceneJouer()
    {
        SceneManager.LoadScene("Map Ld");
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Méthode pour charger la scène "Controls"
    public void ChargerSceneControls()
    {
        SceneManager.LoadScene("Controls");
        Time.timeScale = 1.0f;
    }

    // Méthode pour charger la scène "Controls"
    public void ChargerSceneGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
        Time.timeScale = 1.0f;
    }

    // Méthode pour quitter l'application
    public void QuitterApplication()
    {
        Debug.Log("Application quittée."); // Message pour vérifier dans l'éditeur Unity
        Application.Quit();
    }
}
