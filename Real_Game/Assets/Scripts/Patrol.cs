﻿using UnityEngine;
using System.Collections;
using com.afroraydude.unity.firstgame.inner;

public class Patrol : MonoBehaviour 
{
	public GameManager manager;
	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;
    public float minRemainingDistance = 0.5f;
	
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		
		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = true;
		
		GotoNextPoint();
		manager = manager.GetComponent<GameManager> ();
	}
	
	
	void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0)
			return;
		
		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;
		
		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
	}
	
	
	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		if (!manager.paused) {
			if (agent.remainingDistance < minRemainingDistance) {
				GotoNextPoint ();
			}
			agent.enabled = true;
		} 
		if (manager.paused) { 
			agent.enabled = false;
		}
	}
}