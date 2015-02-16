using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public GameManager manager;

	public float moveSpeed;
	private float maxSpeed = 5f;
	public int deathCount;
	public float killY = -1.5f;

	public GameObject deathParticals;

	private Vector3 input;
	private Vector3 spawn;

	// Use this for initialization
	void Start () 
	{
		spawn = transform.position;
		manager = manager.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		input = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if(rigidbody.velocity.magnitude < maxSpeed) 
		{
			rigidbody.AddForce(input * moveSpeed);
		}
		if (transform.position.y <= killY)
		{
			Die ();
		}
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
		Instantiate(deathParticals, transform.position, Quaternion.identity);
		transform.position = spawn;
	}
	
}
