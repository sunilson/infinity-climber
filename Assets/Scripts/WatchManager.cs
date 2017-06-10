using UnityEngine;
using System.Collections;

public class WatchManager : MonoBehaviour
{

	public static WatchManager instance;
	public AudioClip watchClip;

	public GameObject[] watches;
	public int watchAmount;
	public int watchValue = 100;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	void Start ()
	{
		watchAmount = 0;
	}

	bool reduceWatch ()
	{
		if (watchAmount > 0) {
			for (int i = 0; i < watches.Length; i++) {
				if (watches [i].gameObject.activeInHierarchy) {
					watches [i].gameObject.SetActive (false);
					break;
				}
			}

			watchAmount--;
			return true;
		} else {
			scorePopupScript.instance.popUpScoreText ("No Watch!");
			return false;
		}
	}

	public void addWatch ()
	{
		ItemAudioSource.instance.playAudioClip (watchClip);
		if (watchAmount < watches.Length) {
			watchAmount++;
			scorePopupScript.instance.popUpScoreText ("+1 Watch");
			for (int i = watches.Length - 1; i >= 0; i--) {
				if (!watches [i].gameObject.activeInHierarchy) {
					watches [i].gameObject.SetActive (true);
					break;
				}
			}
		} else {
			ScoreController.instance.addToCurrentScore (watchValue);
			scorePopupScript.instance.popUpScoreText ("+" + watchValue);
		}
	}

	public void activateWatch ()
	{
		if (!GameController.instance.alreadySlowed) {
			if (reduceWatch ()) {
				GameController.instance.alreadySlowed = true;
				GameController.instance.slowDownTime ();
			}
		}
	}
}
