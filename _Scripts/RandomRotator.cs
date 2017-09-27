using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	private Rigidbody asteroid;
	public float tumble;

	// Use this for initialization
	void Start () {
		asteroid = GetComponent<Rigidbody>();
		asteroid.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
