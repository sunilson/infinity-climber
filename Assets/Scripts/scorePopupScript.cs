using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scorePopupScript : MonoBehaviour
{

	private Animator anim;

	public static scorePopupScript instance;
	private Text scorePopup;

	void Awake ()
	{
		MakeInstance ();
	}

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		scorePopup = GetComponent<Text> ();
	}

	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	public void popUpScoreText (string score)
	{
		scorePopup.text = score;

		StartCoroutine (playAnimations ());
	}

	IEnumerator playAnimations ()
	{
		anim.Play ("TextPopUp");
		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (0.7f));
		anim.Play ("TextFadeOut");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
