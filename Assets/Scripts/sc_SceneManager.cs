using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class sc_SceneManager : MonoBehaviour
{
    // Méthode pour charger la scène "Jouer"
    public void ChargerSceneJouer()
    {
        SceneManager.LoadScene("Game");
    }

    // Méthode pour charger la scène "Controls"
    public void ChargerSceneControls()
    {
        SceneManager.LoadScene("Controls");
    }

    // Méthode pour quitter l'application
    public void QuitterApplication()
    {
        Debug.Log("Application quittée."); // Message pour vérifier dans l'éditeur Unity
        Application.Quit();
    }
}
