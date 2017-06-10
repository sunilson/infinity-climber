using UnityEngine;
using System.Collections;

public class ItemAudioSource : MonoBehaviour
{

	private AudioSource audioSource;

	public static ItemAudioSource instance;

	public void playAudioClip (AudioClip audioClip)
	{
		audioSource.PlayOneShot (audioClip);
	}

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
		audioSource = GetComponent<AudioSource> ();
	}

}
