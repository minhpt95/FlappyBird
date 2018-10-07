using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private const string HIGH_SCORE = "High Score";

    private const string ID_BG = "ID Background";

    private const string ID_BIRD = "ID Bird";

	void Awake(){
		_MakeSingleInstance ();
		IsGameStartedForTheFirstTime ();
	}

	void IsGameStartedForTheFirstTime(){
		if (!PlayerPrefs.HasKey ("IsGameStartedForTheFirstTime")) {
			PlayerPrefs.SetInt (HIGH_SCORE, 0);
            PlayerPrefs.SetInt(ID_BG, 1);
            PlayerPrefs.SetInt(ID_BIRD, 1);
			PlayerPrefs.SetInt ("IsGameStartedForTheFirstTime", 0);
		}
	}

	void _MakeSingleInstance(){
		if (instance != null) {
            Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void SetHighScore(int score){
		PlayerPrefs.SetInt (HIGH_SCORE, score);
	}

	public int GetHighScore(){
		return PlayerPrefs.GetInt (HIGH_SCORE);
	}

    public void SetIDBackground(int idBG){
        PlayerPrefs.SetInt(ID_BG, idBG);   
    }

    public int GetIDBackground()
    {
        return PlayerPrefs.GetInt (ID_BG);
    }

    public void SetIDBird(int idBird)
    {
        PlayerPrefs.SetInt(ID_BIRD, idBird);
    }

    public int GetIDBird(){
        return PlayerPrefs.GetInt(ID_BIRD);
    }
    
}
