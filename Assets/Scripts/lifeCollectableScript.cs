using UnityEngine;
using System.Collections;

public class lifeCollectableScript : MonoBehaviour
{
	public AudioClip lifeClip;

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") {
			lifeManager.instance.addHealth ();
			ItemAudioSource.instance.playAudioClip (lifeClip);
			Destroy (gameObject);
		}
	}
}
