using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConnectedTextScript : MonoBehaviour
{

	public static ConnectedTextScript instance;

	// Use this for initialization
	void Start ()
	{

		if (instance == null) {
			instance = this;
		}
	
	}

	public void changeText (string text)
	{
		GetComponent<Text> ().text = text;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
