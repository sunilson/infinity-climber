using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeaderBoardsButton : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
	{
		GetComponent<Button> ().onClick.AddListener (() => LeaderboardController.instance.OpenLeaderboard ());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
