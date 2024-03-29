using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_GameState : MonoBehaviour
{
    public static sc_GameState instance;

    public GameObject uiW, uiL;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Gagne()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        uiW.SetActive(true);
    }
    public void Perd()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        uiL.SetActive(true);
    }
}
