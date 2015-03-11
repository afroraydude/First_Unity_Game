using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public GameManager manager;
	
	//public Animator animator;
	public Rigidbody rigid;
	public string walkingStateName = "walking";
	
	public float moveSpeed;
	private float maxSpeed = 5f;
	public int deathCount;
	public float killY = -1.5f;
	public int up = 1;
	public int down = -1;
	public int left = -1;
	public int right = 1;
	
	public GameObject deathParticals;
	
	private Vector3 input;
	private Vector3 spawn;
	
	// Use this for initialization
	void Start () {
		rigid = rigid.GetComponent<Rigidbody> ();
		//animator = animator.GetComponent<Animator>();
		spawn = transform.position;
		manager = manager.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		input = new Vector3 (0, 0, 0);
		if (Input.GetButtonDown("Up") && Input.GetButtonUp("Down")) {
			input.z = (float)up;
		}
		else if (Input.GetButtonDown("Down") && Input.GetButtonUp("Up")) {
			input.z = (float)down;
		}
		else if (Input.GetButtonDown("Left") && Input.GetButtonUp("Right")) {
			input.x = (float)left;
		}
		else if (Input.GetButtonDown("Right") && Input.GetButtonUp("Left")) {
			input.x = (float)right;
		}
		startMoving ();
	}
	
	void startMoving() {
		if(rigid.velocity.magnitude < maxSpeed) 
		{
			rigid.AddForce(input * moveSpeed);
			//animator.Play(walkingStateName);
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