using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBG : MonoBehaviour {

    public static ChangeBG instance;

	// Use this for initialization
    [SerializeField]
    private GameObject BGDay, BGNight, birdBlue, birdGreen, birdRed;

	void Awake()
	{
        _MakeInstance();
        _CheckBird();
        _CheckBG();
	}


	private void _MakeInstance()
    {
        if(instance == null){
            instance = this;
        }
    }

    private void _CheckBG(){
        if (GameManager.instance.GetIDBackground() == 1)
        {
            BGDay.SetActive(true);
            BGNight.SetActive(false);
        }
        else if (GameManager.instance.GetIDBackground() == 2)
        {
            BGDay.SetActive(false);
            BGNight.SetActive(true);
        }
    }

    private void _CheckBird(){
        if (GameManager.instance.GetIDBird() == 1)
        {
            birdBlue.SetActive(true);
            birdGreen.SetActive(false);
            birdRed.SetActive(false);
        }
        else if (GameManager.instance.GetIDBird() == 2)
        {
            birdBlue.SetActive(false);
            birdGreen.SetActive(true);
            birdRed.SetActive(false);
        }
        else if (GameManager.instance.GetIDBird() == 3)
        {
            birdBlue.SetActive(false);
            birdGreen.SetActive(false);
            birdRed.SetActive(true);
        }
    }


    public void _BGChange()
    {
        if (BGDay.activeSelf)
        {
            BGNight.SetActive(true);
            BGDay.SetActive(false);
            GameManager.instance.SetIDBackground(2);
        }
        else if (BGNight.activeSelf)
        {
            BGNight.SetActive(false);
            BGDay.SetActive(true);
            GameManager.instance.SetIDBackground(1);
        }
    }

    public void _BirdChange()
    {
        if (birdBlue.activeSelf)
        {
            birdBlue.SetActive(false);
            birdGreen.SetActive(true);
            birdRed.SetActive(false);
            GameManager.instance.SetIDBird(2);
        }
        else if (birdGreen.activeSelf)
        {
            birdBlue.SetActive(false);
            birdGreen.SetActive(false);
            birdRed.SetActive(true);
            GameManager.instance.SetIDBird(3);
        }
        else if (birdRed.activeSelf)
        {
            birdBlue.SetActive(true);
            birdGreen.SetActive(false);
            birdRed.SetActive(false);
            GameManager.instance.SetIDBird(1);
        }
    }
}
