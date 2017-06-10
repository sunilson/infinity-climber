using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{

	public GameObject[] obstacles;
	public GameObject[] collectables;

	private bool spawnedLongObstacle;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (spawnObstacle ());
		shuffle (obstacles);
		shuffle (collectables);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	IEnumerator spawnObstacle ()
	{
		yield return new WaitForSeconds (Random.Range (0.5f, 1f));

		if (!lifeManager.instance.dead && GameController.instance.gameStarted) {

			float minX = PlayerController.instance.minX + 0.5f;
			float maxX = PlayerController.instance.maxX - 0.5f;

			//is the obstacle targeted for player or not
			if (Random.Range (0f, 1f) < 0.5f) {
				minX = Mathf.Clamp (PlayerController.instance.transform.position.x - 1f, PlayerController.instance.minX + 0.5f, PlayerController.instance.maxX - 0.5f);
				maxX = Mathf.Clamp (PlayerController.instance.transform.position.x + 1f, PlayerController.instance.minX + 0.5f, PlayerController.instance.maxX - 0.5f);
			}
				
			int gameObjectIndex = Random.Range (0, obstacles.Length);

			if (spawnedLongObstacle) {
				while (obstacles [gameObjectIndex].tag == "LongObstacleHolder") {
					gameObjectIndex = Random.Range (0, obstacles.Length);
					spawnedLongObstacle = false;
				}
			}

			GameObject obstacle = Instantiate (obstacles [gameObjectIndex], new Vector3 (Random.Range (minX, maxX), transform.position.y, -5), Quaternion.identity) as GameObject;

			if (obstacles [gameObjectIndex].tag == "LongObstacleHolder") {
				spawnedLongObstacle = true;
				Vector3 temp = obstacle.transform.position;
				temp.x = Mathf.Clamp (temp.x, -2f, 2f);
				obstacle.transform.position = temp;
			}


			obstacle.GetComponent<Obstacle> ().isMoving = true;

			if (Random.Range (0, 10) < 3) {
				yield return new WaitForSeconds (Random.Range (0.5f, 1f));
				GameObject collectable = Instantiate (collectables [Random.Range (0, collectables.Length)], new Vector3 (Random.Range (PlayerController.instance.minX + 0.5f, PlayerController.instance.maxX - 0.5f), transform.position.y, -5), Quaternion.identity) as GameObject;
				collectable.GetComponent<Obstacle> ().isMoving = true;
				yield return new WaitForSeconds (Random.Range (0.5f, 1f));
			} else {
				if (spawnedLongObstacle) {
					yield return new WaitForSeconds (1f);
				} else {
					yield return new WaitForSeconds (Random.Range (0.5f, 1f));
				}
			}
		}

		StartCoroutine (spawnObstacle ());
	}

	void shuffle (GameObject[] array)
	{
		for (int i = 0; i < array.Length; i++) {
			GameObject temp = array [i];
			int randomIndex = Random.Range (i, array.Length);

			array [i] = array [randomIndex];
			array [randomIndex] = temp;
		}
	}
}
