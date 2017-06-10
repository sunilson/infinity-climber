using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AdsController : MonoBehaviour
{

	public static AdsController instance;
	private const string SDK_KEY = "sn7fkO3xatOk-ebH8xznKRTC6onZH-i8mrpUDsPpkoWiQ6-Z1xKMNoTTaJ2sIl_2ZpXofxaOk559B3iD_2ZMr7";

	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void Start ()
	{
		AppLovin.SetSdkKey (SDK_KEY);
		AppLovin.InitializeSdk ();
		AppLovin.SetUnityAdListener (this.gameObject.name);
		StartCoroutine (callAds ());
	}

	public void LoadInterstitial ()
	{
		AppLovin.PreloadInterstitial ();
	}

	public void ShowInterstitial ()
	{
		if (AppLovin.HasPreloadedInterstitial ()) {
			AppLovin.ShowInterstitial ();
		} else {
			LoadInterstitial ();
			AppLovin.ShowInterstitial ();
		}
	}

	public void LoadVideo ()
	{
		AppLovin.LoadRewardedInterstitial ();
	}

	public void ShowVideo ()
	{
		AppLovin.ShowRewardedInterstitial ();
	}

	void Update ()
	{
	
	}

	void onAppLovinEventReceived (string ev)
	{
		if (ev.Contains ("DISPLAYEDINTER")) {
			// An ad was shown.  Pause the game.
		} else if (ev.Contains ("HIDDENINTER")) {
			// Ad ad was closed.  Resume the game.
			// If you're using PreloadInterstitial/HasPreloadedInterstitial, make a preload call here.
			AppLovin.PreloadInterstitial ();
		} else if (ev.Contains ("LOADEDINTER")) {
			// An interstitial ad was successfully loaded.
		} else if (string.Equals (ev, "LOADINTERFAILED")) {
			// An interstitial ad failed to load.
		} else if (ev.Contains ("LOADEDREWARDED")) {
			// A rewarded video was successfully loaded.
		} else if (ev.Contains ("LOADREWARDEDFAILED")) {
			LoadVideo ();
		} else if (ev.Contains ("HIDDENREWARDED")) {
			// A rewarded video was closed.  Preload the next rewarded video.
			LoadVideo ();
		}
	}

	IEnumerator callAds ()
	{
		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (3f));
		LoadInterstitial ();
		LoadVideo ();
	}

	void OnLevelWasLoaded ()
	{
		if (SceneManager.GetActiveScene ().name == "MainMenu") {
			int random = Random.Range (0, 10);
			if (random > 5) {
				ShowInterstitial ();
			} else {
				ShowVideo ();
			}
		}
	}
}
