using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour
{

	public static MainMenuController instance;

	void Awake ()
	{
		MakeInstance ();
	}

	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	public void PlayGame ()
	{
		SceneFader.instance.FadeIn ("Gameplay");
	}

	public void viewLeaderboard ()
	{
		
	}
}
