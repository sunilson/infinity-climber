using UnityEngine;
using System.Collections;

public class BackgroundScaler : MonoBehaviour
{

	private float width, height;

	// Use this for initialization
	void Start ()
	{
		height = Camera.main.orthographicSize * 2f;
		width = height * Screen.width / Screen.height;

		transform.localScale = new Vector3 (width + 2f, height + 2f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
