using UnityEngine;
using System.Collections;

public class RatingPanelController : MonoBehaviour
{

	public static RatingPanelController instance;

	// Use this for initialization
	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void disable ()
	{
		gameObject.SetActive (false);
		PlayerController.instance.finishedGame ();
	}

	public void rate ()
	{
		Application.OpenURL ("market://details?id=com.Sunilson.InfinityClimber");
		gameObject.SetActive (false);
		PlayerController.instance.finishedGame ();
	}
}
