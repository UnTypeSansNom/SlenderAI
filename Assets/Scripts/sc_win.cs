using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_win : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        sc_GameState.instance.Gagne();
    }
}
