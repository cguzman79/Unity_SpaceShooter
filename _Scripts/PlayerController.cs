using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	//boundaries for ship movement.
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	//game variables
	public float speed;
	public float tilt;
	public Boundary boundary;
	private Rigidbody ship;
	public GameObject shot;
	public Transform shotSpawn;
	private float nextFire;
	public float fireRate;
	private AudioSource shootingSound;

	//sets up the ship at the beginning of the game.
	void Start (){
		ship = GetComponent<Rigidbody>();
		shootingSound = GetComponent<AudioSource> ();
	}

	//updates each frame for the shots fired.
	/*void update(){
		if (Input.GetButton("Jump") && Time.time > nextFire) 
		{		
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

		}
	}*/

	void FixedUpdate ()
	{
		if (Input.GetButton("Jump") && Time.time > nextFire) 
		{		
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			shootingSound.Play ();
		}

		//Moving left and right.
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		ship.velocity = movement * speed;

		//out of bounds validation
		ship.position = new Vector3 
			(
				Mathf.Clamp (ship.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (ship.position.z, boundary.zMin, boundary.zMax)
			);
		
		//tilting
		ship.rotation = Quaternion.Euler (0.0f, 0.0f, ship.velocity.x * -tilt);
	}
}
