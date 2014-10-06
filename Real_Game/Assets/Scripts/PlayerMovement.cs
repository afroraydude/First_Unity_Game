using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	private float maxSpeed = 5f;
	public GameObject deathParticals;

	private Vector3 input;
	private Vector3 spawn;

	// Use this for initialization
	void Start () 
	{
		spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		input = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if(rigidbody.velocity.magnitude < maxSpeed) 
		{
			rigidbody.AddForce(input * moveSpeed);
		}
		if (transform.position.y < -2)
		{
			Die ();
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy")
		{
			Die ();
		}
	}

	void OnTrigerEnter(Collider other)
	{
		if (other.transform.tag == "Goal")
		{
			GameManager.CompleteLevel();
		}
	}

	void Die()
	{
		Instantiate(deathParticals, transform.position, Quaternion.identity);
		transform.position = spawn;
	}
}
