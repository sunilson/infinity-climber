using UnityEngine;
using System.Collections;

public class BeeBehaviour : MonoBehaviour
{

	private bool left = false;

	// Use this for initialization
	void Awake ()
	{
		if (Random.Range (0, 1) >= 0.5f) {
			left = true;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!left) {
			Vector3 temp = transform.position;
			temp.x += (GetComponent<Obstacle> ().speed / 1.5f) * Time.deltaTime;
			Mathf.Clamp (temp.x, PlayerController.instance.minX, PlayerController.instance.maxX);
			transform.position = temp;

			if (transform.position.x >= (PlayerController.instance.maxX - Random.Range (0f, 1f))) {
				left = true;
			}
		} else {
			Vector3 temp = transform.position;
			temp.x -= (GetComponent<Obstacle> ().speed / 1.5f) * Time.deltaTime;
			Mathf.Clamp (temp.x, PlayerController.instance.minX, PlayerController.instance.maxX);
			transform.position = temp;

			if (transform.position.x <= (PlayerController.instance.minX + Random.Range (0f, 2f))) {
				left = false;
			}
		}
	}
}
