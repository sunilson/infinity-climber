using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardController : MonoBehaviour
{

	public static LeaderboardController instance;

	private const string LEADERBOARD = "CgkIsLKFzt0UEAIQBg";

	void Start ()
	{
		PlayGamesPlatform.Activate ();
		if (SceneManager.GetActiveScene ().name == "MainMenu") {
			connectDisconnect ();
		}
	}
		
	// Use this for initialization
	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void connectDisconnect ()
	{
		Social.localUser.Authenticate ((bool success) => {
			StartCoroutine (disable ());
		});
	}

	IEnumerator disable ()
	{
		if (ConnectedTextScript.instance != null) {
			ConnectedTextScript.instance.changeText ("Connected to Google Play Games Services");
			yield return new WaitForSeconds (2f);
			ConnectedTextScript.instance.changeText ("");
		}
	}

	public void OpenLeaderboard ()
	{
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI (LEADERBOARD);
		} else {
			connectDisconnect ();
		}
	}

	public void ReportProgress (string ID)
	{
		if (Social.localUser.authenticated) {
			Social.ReportProgress (ID, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
	}

	public void ReportScore (int score)
	{
		if (Social.localUser.authenticated) {
			Social.ReportScore (score, LEADERBOARD, (bool success) => {
			});
		}
	}
}
