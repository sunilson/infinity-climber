﻿using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{

	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
