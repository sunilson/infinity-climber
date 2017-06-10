using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lifeManager : MonoBehaviour
{

	public Image[] lifes;
	public int health;
	public int lifeValue = 200;
	public static lifeManager instance;

	public bool dead = false;

	// Use this for initialization
	void Awake ()
	{
		MakeInstance ();
		health = lifes.Length;
	}

	public void enableHealth ()
	{
		for (int i = 0; i < lifes.Length; i++) {
			lifes [i].gameObject.SetActive (true);
		}
	}

	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	public void reduceHealth ()
	{
		for (int i = lifes.Length - 1; i >= 0; i--) {
			if (lifes [i].gameObject.activeInHierarchy) {
				lifes [i].gameObject.SetActive (false);
				break;
			}
		}

		health--;

		if (health <= 0) {
			hasDied ();
			scorePopupScript.instance.popUpScoreText ("Game Over!");
		} else {
			scorePopupScript.instance.popUpScoreText ("-1 Life");
		}
	}

	public void addHealth ()
	{
		if (health < lifes.Length) {
			health++;
			scorePopupScript.instance.popUpScoreText ("+1 Life");
			for (int i = 0; i < lifes.Length; i++) {
				if (!lifes [i].gameObject.activeInHierarchy) {
					lifes [i].gameObject.SetActive (true);
					break;
				}
			}
		} else {
			ScoreController.instance.addToCurrentScore (lifeValue);
			scorePopupScript.instance.popUpScoreText ("+" + lifeValue);
		}
	}

	void hasDied ()
	{
		dead = true;
		Time.timeScale = 1f;
	}

	// Update is called once per frame
	void Update ()
	{
	}
}
