using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
	public bool isMoving = false;
	public float speed = 2f;
	public float obstacleSpeedGainMultiplicator = 17f;

	// Use this for initialization
	void Start ()
	{
	}

	void Awake ()
	{
		speed = speed + BackgroundLooper.instance.speed * obstacleSpeedGainMultiplicator;
	}

	void Update ()
	{
		if (isMoving) {
			Vector3 temp = transform.position;
			temp.y -= speed * Time.deltaTime;
			transform.position = temp;
		}
	}
}
