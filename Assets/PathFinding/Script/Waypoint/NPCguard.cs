using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NPCguard : MonoBehaviour {
	[SerializeField]
	bool patrolWaiting;
	[SerializeField]
	float totalWaitTime;
	[SerializeField]
	float switchProbability;
	[SerializeField]
	List<Waypoint> patrolPoints;

	//private variable for base behaviour
	NavMeshAgent agent;
	ThirdPersonCharacter character;
	int currentPatrolIndex;
	bool travelling;
	bool waiting;
	bool patrolForward;
	float waitTimer;

	// Use this for initialization
	void Start () {
		agent = this.GetComponent<NavMeshAgent>();
		character = this.GetComponent<ThirdPersonCharacter>();
		agent.updateRotation = false;
		if(agent != null)
		{
			if(patrolPoints != null && patrolPoints.Count >= 2)
			{
				currentPatrolIndex = 0;
				SetDestination();
			}
		}else
		{
			Debug.LogError("insert navmeshAgent to"+ gameObject.name);
		}
	}

	void Update() {

		if(agent.remainingDistance > agent.stoppingDistance)
		{
			character.Move(agent.desiredVelocity, false, false);
		}else
		{
			character.Move(Vector3.zero, false, false);
		}

		if(travelling && agent.remainingDistance <= 1.0f)
		{
			//untuk delay sesaat
			travelling = false;
			if(patrolWaiting){
				waiting = true;
				waitTimer = 0f;
			}else
			{
				ChangePatrolPoint();
				SetDestination();
			}
		}

		//jika tanpa delay
		if(waiting)
		{
			waitTimer += Time.deltaTime;
			if(waitTimer >= totalWaitTime)
			{
				waiting = false;
				ChangePatrolPoint();
				SetDestination();
			}
		}
	}

    private void SetDestination()
    {
        if(patrolPoints != null)
		{
			Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
			agent.SetDestination(targetVector);
			travelling = true;
		}
    }

    private void ChangePatrolPoint()
    {
        if(UnityEngine.Random.Range(0f, 1f) <= switchProbability)
		{
			patrolForward = !patrolForward;
		}

		if(patrolForward)
		{
			currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
		}else
		{
			if(--currentPatrolIndex <0){
				currentPatrolIndex = patrolPoints.Count - 1;
			}
		}
    }
}
