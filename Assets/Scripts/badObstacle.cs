using UnityEngine;
using System.Collections;

public class badObstacle : MonoBehaviour
{

	public AudioClip hitClip;

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "Player") {
			ItemAudioSource.instance.playAudioClip (hitClip);

			GameObject[] longObstacles = GameObject.FindGameObjectsWithTag ("LongObstacleHolder");
			for (int i = 0; i < longObstacles.Length; i++) {
				Destroy (longObstacles [i]);
			}
		
			GameObject[] gameobjects = GameObject.FindGameObjectsWithTag ("Obstacle");
			for (int i = 0; i < gameobjects.Length; i++) {
				Destroy (gameobjects [i]);
			}

			GameObject[] collectables = GameObject.FindGameObjectsWithTag ("Collectable");
			for (int i = 0; i < collectables.Length; i++) {
				Destroy (collectables [i]);
			}

		}
	}

}
