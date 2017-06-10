using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackgroundLooper : MonoBehaviour
{

	public float speed = 0.1f;
	public float playerSideSpeedGain = 0.05f;
	public float backgroundSpeedGain = 0.015f;
	public static BackgroundLooper instance;

	private Material mat;
	private Vector2 offset = Vector2.zero;

	// Use this for initialization
	void Start ()
	{
		MakeInstance ();
		mat = GetComponent<Renderer> ().material;
		offset = mat.GetTextureOffset ("_MainTex");
		StartCoroutine (adjustScrollSpeed ());
	}

	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		offset.y += Mathf.Clamp (speed, 0f, 6f) * Time.deltaTime;
		mat.SetTextureOffset ("_MainTex", offset);

		if (SceneManager.GetActiveScene ().name != "MainMenu") {
			if (lifeManager.instance.dead) {
				speed = 0.1f;
			}	
		}

	}

	IEnumerator adjustScrollSpeed ()
	{
		yield return new WaitForSeconds (5f);
		if (SceneManager.GetActiveScene ().name != "MainMenu" && GameController.instance.gameStarted && !lifeManager.instance.dead) {
			speed += backgroundSpeedGain;
			PlayerController.instance.sideSpeed += playerSideSpeedGain;
		}
			
		StartCoroutine (adjustScrollSpeed ());
	}
}
