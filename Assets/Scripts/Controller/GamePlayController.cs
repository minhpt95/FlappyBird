using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{

    public static GamePlayController instance;

    [SerializeField]
    private Button instructionButton, pauseButton;

    [SerializeField]
    private Text scoreText, currentScoreText, bestScoreText, pauseCurrentScore, lastBestScore;

    [SerializeField]
    private GameObject gameOverPanel, pausePanel;

    [SerializeField]
    private GameObject BGDay, BGNight, birdBlue, birdGreen, birdRed;

    [SerializeField]
    private Image blackBG;

    private int scoreGP;

    private void Start()
    {
        
        _BGChange();
        _BirdChange();
        LockResolution._LockResolution();
        SceneFader.instance.FadeIn();
       
    }


    void Awake()
    {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        _MakeInstance();

    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void _InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void _SetScore(int score)
    {
        scoreGP = score; //take score from Pl
        scoreText.text = "" + score;
    }

    public void _BirdDiedShowPanel(int score)
    {
        gameOverPanel.SetActive(true);

        pauseButton.gameObject.SetActive(false);

        currentScoreText.text = "" + score;

        if (score > GameManager.instance.GetHighScore())
        {
            GameManager.instance.SetHighScore(score);
        }
        bestScoreText.text = "" + GameManager.instance.GetHighScore();

        if (score < 20)
        {
            MedalController.instance._BronzeMedal();
        }
        else if (score >= 20 && score < 40)
        {
            MedalController.instance._SilverMedal();
        }
        else
        {
            MedalController.instance._GoldMedal();
        }
    }

    public void _MenuButton()
    {
        SceneFader.instance.FadeOut("MainMenu"); //back to menu
    }

    public void _RestartGameButton()
    {
        Application.LoadLevel(Application.loadedLevel); // restart current level
    }

    public void _PauseButton()
    {
        Time.timeScale = 0; // to stop frame

        pauseButton.gameObject.SetActive(false);

        pausePanel.SetActive(true);

        pauseCurrentScore.text = "" + scoreGP;

        lastBestScore.text = "" + GameManager.instance.GetHighScore();

        if (GameManager.instance.GetHighScore() < 20)
        {
            MedalController.instance._PauseBronze();
        }
        else if (GameManager.instance.GetHighScore() >= 20 && GameManager.instance.GetHighScore() < 40)
        {
            MedalController.instance._PauseSilver();
        }
        else
        {
            MedalController.instance._PauseGold();
        }
    }

    public void _ResumeButton()
    {
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void _BGChange()
    {
        if (GameManager.instance.GetIDBackground() == 1)
        {
            BGNight.SetActive(false);
            BGDay.SetActive(true);
        }
        else if (GameManager.instance.GetIDBackground() == 2)
        {
            BGNight.SetActive(true);
            BGDay.SetActive(false);
        }
    }

    public void _BirdChange()
    {
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

}
