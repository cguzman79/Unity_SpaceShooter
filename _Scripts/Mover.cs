using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	private Rigidbody bolt;

	// Use this for initialization
	void Start () {
		//initialize the rigidbody for bolt.
		bolt = GetComponent<Rigidbody> ();

		//allow movement of bolt.
		bolt.velocity = transform.forward * speed;
	}
	

}
