using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {
	private AudioSource fon;
	void Start () {
		fon = GetComponent<AudioSource>();
		fonning ();
	}
	void fonning(){
		fon.Play ();
	}
}
