using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class sc_SoundManager : MonoBehaviour
{
    public static sc_SoundManager instance;
    public sc_CharacterController characterController;
    public sc_Statue statueController;
    public sc_KeyManager keyManager;

    public Transform player;
    public Transform statue;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource cameraOnSFX;
    public AudioSource footstepsWalkingSFX;
    public AudioSource flashlightSwitchSFX;
    public AudioSource keyCollectedSFX;
    public AudioSource gateOpeningSFX;

    public AudioSource monsterFishScreamer1SFX;
    public AudioSource monsterFishScreamer2SFX;
    public AudioSource monsterFishScreamer3SFX;
    public AudioSource monsterFishScreamer4SFX;
    public AudioSource virginStatueMovesSFX;
    public AudioSource virginStatueIsCloseSFX;
    public AudioSource virginStatueScreamerSFX;

    void Start()
    {
        cameraOnSFX = GetComponent<AudioSource>();
        footstepsWalkingSFX = GetComponent<AudioSource>();
        flashlightSwitchSFX = GetComponent<AudioSource>();
        keyCollectedSFX = GetComponent<AudioSource>();
        gateOpeningSFX = GetComponent<AudioSource>();

        monsterFishScreamer1SFX = GetComponent<AudioSource>();
        monsterFishScreamer2SFX = GetComponent<AudioSource>();
        monsterFishScreamer3SFX = GetComponent<AudioSource>();
        monsterFishScreamer4SFX = GetComponent<AudioSource>();
        virginStatueMovesSFX = GetComponent<AudioSource>();
        virginStatueIsCloseSFX = GetComponent<AudioSource>();
        virginStatueScreamerSFX = GetComponent<AudioSource>();
    }

    public void PlayCameraOnSFX()
    {
        cameraOnSFX.Play();
    }

    public void PlayFootstepsWalkingSFX()
    {
        if(characterController.isMoving == true)
        {
            footstepsWalkingSFX.Play();
        }
    }

    public void PlayFlashlightSwitchSFX()
    {
        flashlightSwitchSFX.Play();
    }

    public void PlayKeyCollected()
    {
        keyCollectedSFX.Play();
    }

    public void PlayGateOpeningSFX()
    {
        gateOpeningSFX.Play();
    }

    public void PlayMonsterFish()
    {
        StartCoroutine(PlayRandomFishMonsterSFX());
    }

    private IEnumerator PlayRandomFishMonsterSFX()
    {
        int fishMonsterScreamerInstance = Random.Range(1, 4);
        if (fishMonsterScreamerInstance == 1)
        {
            monsterFishScreamer1SFX.Play();
        }
        else if (fishMonsterScreamerInstance == 2)
        {
            monsterFishScreamer2SFX.Play();
        }

        else if (fishMonsterScreamerInstance == 3)
        {
            monsterFishScreamer3SFX.Play();
        }
        else if (fishMonsterScreamerInstance == 4)
        {
            monsterFishScreamer4SFX.Play();
        }
        yield return new WaitForSeconds(5);
    }

    public void PlayVirginStatueMoves()
    {
        if (statueController.isChasing)
        {
            virginStatueMovesSFX.Play();
        }
    }

    public void PlayVirginStatueIsClose()
    {
        float distanceStatue = Vector3.Distance(statue.position, player.position);
        if(distanceStatue < 2)
        {
            virginStatueIsCloseSFX.Play();
        }
    }

    public void PlayVirginStatueScreamer()
    {
        virginStatueScreamerSFX.Play();
    }
}
