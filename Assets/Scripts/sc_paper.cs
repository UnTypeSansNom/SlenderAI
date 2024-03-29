using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_paper : MonoBehaviour
{
    public GameObject paperUI;



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            paperUI.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void closePaper()
    {
        paperUI?.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
