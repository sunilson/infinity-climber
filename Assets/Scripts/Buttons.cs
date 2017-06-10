using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

	public GameObject player;

	public static bool leftTap, rightTap;
	private static float leftTime, rightTime;

	private bool tappedBoth = false;
	private float tapTime;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
	}

	public void OnPointerDown (PointerEventData data)
	{
		if (gameObject.name == "ButtonLeft") {
			leftTime = Time.time;
		} else {
			rightTime = Time.time;
		}

		if (Mathf.Abs (rightTime - leftTime) <= 0.1f) {
			WatchManager.instance.activateWatch ();
			tappedBoth = true;
			player.GetComponent<PlayerController> ().moveLeft = false;
			player.GetComponent<PlayerController> ().moveRight = false;
		} else {
			if (!tappedBoth) {
				if (gameObject.name == "ButtonLeft") {
					player.GetComponent<PlayerController> ().moveLeft = true;
					player.GetComponent<PlayerController> ().moveRight = false;
				} else if (gameObject.name == "ButtonRight") {
					player.GetComponent<PlayerController> ().moveLeft = false;
					player.GetComponent<PlayerController> ().moveRight = true;
				}
			}
		}
	}

	public void OnPointerUp (PointerEventData data)
	{
		tappedBoth = false;
		player.GetComponent<PlayerController> ().moveLeft = false;
		player.GetComponent<PlayerController> ().moveRight = false;
	}
}
