﻿using UnityEngine;
using System.Collections;

public class Patrol2 : MonoBehaviour {
	public Transform[] patrolPoints;
	private int destPoint = 0;
	private NavMeshAgent agent;
	
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		
		// Disabling auto-braking allows for continuous movement
		// between patrolPoints (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;
		
		GotoNextPoint();
	}
	
	
	void GotoNextPoint() {
		// Returns if no patrolPoints have been set up
		if (patrolPoints.Length == 0) {
			return;
		}
		// Set the agent to go to the currently selected destination.
		agent.destination = patrolPoints[destPoint].position;
		
		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % patrolPoints.Length;
	}
	
	
	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		if (agent.remainingDistance < 0.5f)
			GotoNextPoint();
	}
}
