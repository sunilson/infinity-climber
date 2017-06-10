using UnityEngine;
using System.Collections;

public class diamondScript : MonoBehaviour
{

	public int value;
	public AudioClip coinClip;

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") {
			ItemAudioSource.instance.playAudioClip (coinClip);
			ScoreController.instance.addToCurrentScore (value);
			ScoreController.instance.updateScore ();
			scorePopupScript.instance.popUpScoreText ("+" + value);
			Destroy (gameObject);
		}

	}
}
