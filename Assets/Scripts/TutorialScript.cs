using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

	public void startGame ()
	{
		gameObject.SetActive (false);
		GameController.instance.gameStarted = true;
		lifeManager.instance.enableHealth ();
	}
}
