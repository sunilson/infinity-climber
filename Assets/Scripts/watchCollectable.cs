using UnityEngine;
using System.Collections;

public class watchCollectable : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") {
			WatchManager.instance.addWatch ();
			Destroy (gameObject);
		}
	}
}
