using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalController : MonoBehaviour {

    public static MedalController instance;

    [SerializeField]
    private Image bronzeMedal, silverMedal, goldMedal, pauseBronzeMedal, pauseSilverMedal, pauseGoldMedal;

	void Awake()
	{
        _MakeInstance();
	}

    void _MakeInstance()
    {
        if(instance == null){
            instance = this;
        }    
    }

	public void _BronzeMedal()
    {
        bronzeMedal.gameObject.SetActive(true);
        silverMedal.gameObject.SetActive(false);
        goldMedal.gameObject.SetActive(false);
    }

    public void _PauseBronze(){
        pauseBronzeMedal.gameObject.SetActive(true);
        pauseSilverMedal.gameObject.SetActive(false);
        pauseGoldMedal.gameObject.SetActive(false);
    }

    public void _SilverMedal()
    {
        bronzeMedal.gameObject.SetActive(false);
        silverMedal.gameObject.SetActive(true);
        goldMedal.gameObject.SetActive(false);
    }

    public void _PauseSilver(){
        pauseBronzeMedal.gameObject.SetActive(false);
        pauseSilverMedal.gameObject.SetActive(true);
        pauseGoldMedal.gameObject.SetActive(false);
    }

    public void _GoldMedal()
    {
        bronzeMedal.gameObject.SetActive(false);
        silverMedal.gameObject.SetActive(false);
        goldMedal.gameObject.SetActive(true);
    }

    public void _PauseGold(){
        pauseBronzeMedal.gameObject.SetActive(false);
        pauseSilverMedal.gameObject.SetActive(false);
        pauseGoldMedal.gameObject.SetActive(true);
    }
}
