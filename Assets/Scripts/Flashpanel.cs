using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Flashpanel : MonoBehaviour
{

	private Animator anim;

	public static Flashpanel instance;

	void Awake ()
	{
		MakeInstance ();
	}

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	public void flash ()
	{
		anim.Play ("FlashPanel");
	}
}
