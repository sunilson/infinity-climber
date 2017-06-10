using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
	public static SceneFader instance;

	public GameObject fadeCanvas;
	public Animator fadeAnim;

	// Use this for initialization
	void Awake ()
	{
		MakeSingleton ();
	}

	void MakeSingleton ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void FadeIn (string levelName)
	{
		StartCoroutine (FadeInAnimation (levelName));
	}

	public void FadeOut ()
	{
		StartCoroutine (FadeOutAnimation ());
	}

	IEnumerator FadeInAnimation (string levelName)
	{
		fadeCanvas.SetActive (true);
		fadeAnim.Play ("FaderFadeIn");
		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (.7f));
		SceneManager.LoadScene (levelName);
		FadeOut ();
	}

	IEnumerator FadeOutAnimation ()
	{
		fadeAnim.Play ("FaderFadeOut");
		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (1f));
		fadeCanvas.SetActive (false);
	}
}
