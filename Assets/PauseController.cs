using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{
	public GameObject pausePanel;

	void Awake ()
	{
	}

	public void PauseGame ()
	{
		if (pausePanel.activeInHierarchy) {
			ExitPause ();
		} else {
			pausePanel.SetActive (true);
			AudioListener.pause = true;
			Time.timeScale = 0f;
		}		
	}


	public void ExitPause ()
	{
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
		AudioListener.pause = false;
	}
}
