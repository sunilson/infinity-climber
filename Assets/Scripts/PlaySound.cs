using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour
{

	public AudioClip clip;


	// Use this for initialization
	void Start ()
	{
		GetComponent<Button> ().onClick.AddListener (() => playSound ());
	}

	void playSound ()
	{
		ItemAudioSource.instance.playAudioClip (clip);
		GetComponent<Animator> ().Play ("ButtonClick");
	}
}
