using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

	public static ScoreController instance;
	public Text scoreText;
	public bool s1000, s2000, s3000, s4000, s5000;

	private int score = 0;

	// Use this for initialization
	void Start ()
	{
		MakeInstance ();
		StartCoroutine (countScore ());
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
		if (lifeManager.instance.dead) {
			if (score > PlayerPrefs.GetInt ("Score")) {
				PlayerPrefs.SetInt ("Score", score);
			}
		}

		if (score >= 1000) {
			if (!s1000) {
				LeaderboardController.instance.ReportProgress ("CgkIsLKFzt0UEAIQAQ");
			}
			s1000 = true;
		}

		if (score >= 2000) {
			if (!s2000) {
				LeaderboardController.instance.ReportProgress ("CgkIsLKFzt0UEAIQAg");
			}
			s2000 = true;
		}

		if (score >= 3000) {
			if (!s3000) {
				LeaderboardController.instance.ReportProgress ("CgkIsLKFzt0UEAIQAw");
			}
			s3000 = true;
		}

		if (score >= 4000) {
			if (!s4000) {
				LeaderboardController.instance.ReportProgress ("CgkIsLKFzt0UEAIQBA");
			}
			s4000 = true;
		}

		if (score >= 5000) {
			if (!s5000) {
				LeaderboardController.instance.ReportProgress ("CgkIsLKFzt0UEAIQBQ");
			}
			s5000 = true;
		}
	}

	IEnumerator countScore ()
	{
		yield return new WaitForSeconds ((0.6f / (BackgroundLooper.instance.speed * 10)) / 0.8f);
		if (!lifeManager.instance.dead && GameController.instance.gameStarted) {
			score += 1;
			scoreText.text = score + "";
		}

		StartCoroutine (countScore ());
	}

	public void setScore (int Score)
	{
		PlayerPrefs.SetInt ("Score", Score);
	}

	public int getScore ()
	{
		return PlayerPrefs.GetInt ("Score");
	}

	public int getCurrentScore ()
	{
		return score;
	}

	public void addToCurrentScore (int value)
	{
		score += value;
	}

	public void updateScore ()
	{
		scoreText.text = score + "";
	}
}
