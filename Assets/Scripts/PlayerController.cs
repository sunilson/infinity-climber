using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public static PlayerController instance;

	public float upSpeed = 4f;
	public float sideSpeed = 5f;
	public Button leftButton, rightButton;
	public bool moveRight = false;
	public bool moveLeft = false;
	public float minX, maxX;
	public GameObject endPanel;
	public int longObstacleValue = 50;
	public AudioClip coinSound;

	private bool isHit = false;

	// Use this for initialization
	void Start ()
	{
		MakeInstance ();
		MinMaxBounds ();
	}

	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	void MinMaxBounds ()
	{
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

		maxX = bounds.x;
		minX = -bounds.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameController.instance.gameStarted) {
			if (transform.position.y < -2 && !isHit && !lifeManager.instance.dead) {
				Vector3 temp = transform.position;
				temp.y += upSpeed * Time.deltaTime;
				transform.position = temp;
			}

			if (isHit) {
				Vector3 temp = transform.position;
				temp.y -= upSpeed * 5 * Time.deltaTime;
				transform.position = temp;

				if (transform.position.y < -6) {
					isHit = false;
				}
			}

			if (moveLeft) {
				MoveLeft ();
			} else if (moveRight) {
				MoveRight ();
			}

			if (transform.position.x < minX + 0.5f) {
				Vector3 temp = transform.position;
				temp.x = minX + 0.5f;
				transform.position = temp;
			}

			if (transform.position.x > maxX - 0.5f) {
				Vector3 temp = transform.position;
				temp.x = maxX - 0.5f;
				transform.position = temp;
			}
		}
	}

	void MoveLeft ()
	{
		Vector3 temp = transform.position;
		temp.x -= sideSpeed * Time.deltaTime;
		transform.position = temp;
	}

	void MoveRight ()
	{
		Vector3 temp = transform.position;
		temp.x += sideSpeed * Time.deltaTime;
		transform.position = temp;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Obstacle") {
			isHit = true;
			lifeManager.instance.reduceHealth ();
			Flashpanel.instance.flash ();
			Camera.main.GetComponent<PerlinShake> ().PlayShake ();

		} else if (col.gameObject.tag == "LongObstacleHolder") {
			scorePopupScript.instance.popUpScoreText ("+" + longObstacleValue);
			ScoreController.instance.addToCurrentScore (longObstacleValue);
			ItemAudioSource.instance.playAudioClip (coinSound);
		}
	}

	public void hasDied ()
	{
		StartCoroutine (hasDiedCoroutine ());
	}

	IEnumerator hasDiedCoroutine ()
	{
		
		PlayerPrefs.SetInt ("Died", PlayerPrefs.GetInt ("Died") + 1);
		LeaderboardController.instance.ReportScore (ScoreController.instance.getCurrentScore ());
		WatchManager.instance.gameObject.SetActive (false);
		yield return new WaitForSeconds (1f);
		GameObject.Find ("PauseButton").SetActive (false);

		if (Random.Range (0f, 1f) <= 0.3f && PlayerPrefs.GetInt ("Died") != 3) {
			AdsController.instance.ShowInterstitial ();
		}

		if (PlayerPrefs.GetInt ("Died") == 3) {
			RatingPanelController.instance.gameObject.SetActive (true);
		} else {
			finishedGame ();
		}
	}

	public void finishedGame ()
	{
		endPanel.SetActive (true);
		Destroy (gameObject);
	}
}
