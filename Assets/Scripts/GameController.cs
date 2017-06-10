using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public static GameController instance;
	public AudioClip slowDown, speedUp;
	public bool alreadySlowed = false;
	public bool gameStarted = false;

	private float originalSideSpeed;
	private AudioSource audioSource;

	void MakeSingleton ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
	// Use this for initialization
	void Awake ()
	{
		MakeSingleton ();
	}

	void Start ()
	{
		AudioListener.pause = false;
		Screen.fullScreen = false;
		audioSource = GetComponent<AudioSource> ();

		if (!PlayerPrefs.HasKey ("Died")) {
			PlayerPrefs.SetInt ("Died", 0);
		}
	}

	void OnLevelWasLoaded ()
	{
		gameStarted = false;
	}

	public void startGame ()
	{
		SceneFader.instance.FadeIn ("Gameplay");
	}

	public void loadMenu ()
	{
		Time.timeScale = 1f;
		AudioListener.pause = false;
		SceneFader.instance.FadeIn ("MainMenu");
	}

	public void slowDownTime ()
	{
		audioSource.PlayOneShot (slowDown);
		scorePopupScript.instance.popUpScoreText ("Slowed Down");
		Time.timeScale = 0.5f;
		originalSideSpeed = PlayerController.instance.sideSpeed;
		PlayerController.instance.sideSpeed = PlayerController.instance.sideSpeed * 2;
		Invoke ("playResetTimeSound", 2f);
	}

	void playResetTimeSound ()
	{
		audioSource.PlayOneShot (speedUp);
		Invoke ("resetTime", 0.25f);
	}

	private void resetTime ()
	{
		Time.timeScale = 1f;
		PlayerController.instance.sideSpeed = originalSideSpeed;
		alreadySlowed = false;
	}



}
