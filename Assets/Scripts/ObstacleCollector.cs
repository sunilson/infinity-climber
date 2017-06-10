using UnityEngine;
using System.Collections;

public class ObstacleCollector : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "Obstacle") {
			StartCoroutine (destroyObject (target.gameObject));
		} else if (target.tag == "Collectable") {
			StartCoroutine (destroyObject (target.gameObject));
		} else if (target.tag == "Player") {
			if (lifeManager.instance.dead) {
				PlayerController.instance.hasDied ();
			}
		}
	}

	IEnumerator destroyObject (GameObject go)
	{
		yield return new WaitForSeconds (1f);
		Destroy (go);
	}
}
