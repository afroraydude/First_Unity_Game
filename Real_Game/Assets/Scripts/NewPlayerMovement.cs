﻿using UnityEngine;
using System.Collections;

public class NewPlayerMovement : MonoBehaviour {

	public GameManager manager;

	//public Animator animator;
	public Rigidbody rigid;
	public string walkingStateName = "walking";

	public float moveSpeed;
	private float maxSpeed = 5f;
	public int deathCount;
	public float killY = -1.5f;
	public float theExplosionForce = 1f;
	public float theExplosionRadius = 1f;

	public GameObject deathParticals;

	private Vector3 input;
	private Vector3 spawn;

	// Use this for initialization
	void Start () 
	{
		rigid = rigid.GetComponent<Rigidbody> ();
		//animator = animator.GetComponent<Animator>();
		spawn = transform.position;
		manager = manager.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		input = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if(rigid.velocity.magnitude < maxSpeed) 
		{
			rigid.AddForce(input * moveSpeed);
			//animator.Play(walkingStateName);
		}
		if (transform.position.y <= killY)
		{
			Die ();
		}
		rigid.AddExplosionForce (theExplosionForce, transform.position, theExplosionRadius);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Goal")
		{
			manager.CompleteLevel();

		}
		if (other.transform.tag == "Invisible") {
			Die();
		}

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy") {
			Die ();
		}
	}
	

	void Die() {
		deathCount += 1;
		rigid.AddExplosionForce (theExplosionForce, transform.position, theExplosionRadius);
		Instantiate(deathParticals, transform.position, Quaternion.identity);
		transform.position = spawn;
	}
	
}