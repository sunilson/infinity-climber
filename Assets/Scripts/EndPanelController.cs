using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndPanelController : MonoBehaviour
{

	public Text highScore;
	public Text endScore;

	void OnEnable ()
	{
		endScore.text = ScoreController.instance.getCurrentScore ().ToString ();
		highScore.text = ScoreController.instance.getScore ().ToString ();
	}
}
