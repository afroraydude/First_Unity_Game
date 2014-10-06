using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour 
{
	// Size is the amount of points
	public Transform[] patrolPoints;

	private int currentPoint;

	public float moveSpeed;
	// Use this for initialization
	void Start () 
	{
		transform.position = patrolPoints[0].position;
		currentPoint = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position == patrolPoints[currentPoint].position)
		{
			currentPoint++;
		}
		if (currentPoint >= patrolPoints.Length)
		{
			currentPoint = 0;
		}
		transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy")
		{
			print("I think I hit something");
		}
	}
}