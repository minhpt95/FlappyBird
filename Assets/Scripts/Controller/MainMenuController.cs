using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
	private void Start()
	{
        Time.timeScale = 1;
        SceneFader.instance.FadeIn();
        LockResolution._LockResolution();
	}

	public void _PlayButton()
    {
        SceneFader.instance.FadeOut("Flappy");
    }

    public void _BGButton()
    {
        ChangeBG.instance._BGChange(); //change background
    }

    public void _BirdButton()
    {
        ChangeBG.instance._BirdChange(); // change color of bird
    }

}
