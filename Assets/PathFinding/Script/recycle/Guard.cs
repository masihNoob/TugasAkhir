using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Guard : MonoBehaviour {

	public static event System.Action OnGuardSpottedPlayer;

	#region field of view variable
	public float viewRadius;
	[Range(0, 360)]
	public float viewAngle;
	Transform target;
	Vector3 currentWaypoint;
	public LayerMask obstacles;
	public LayerMask targetMask;
	public List<Transform> visibleTarget = new List<Transform>();
	#endregion
	float playerVisibleTimer;
	bool targetNotVisible=true;
    Vector3[] waypoints;
	public Transform pathHolder;
	public float speed = 5f;
	public float waitTime = .3f;
	public float turnSpeed = 90f;
	public float timeToSpot;
	public NavMeshAgent agent;

	private void Start() {
		//agent.updateRotation = false;
		agent.autoBraking = false;
		//targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
		waypoints = new Vector3[pathHolder.childCount];
		for (int i = 0; i < waypoints.Length; i++)
		{
			waypoints[i] = pathHolder.GetChild(i).position;
			waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
		}
		//StartCoroutine(FollowPath(waypoints));
		//GoToNextPoint();
	}
	private void Update() {
		if(!agent.pathPending && agent.remainingDistance < 1f){
			GoToNextPoint();
		}
		if(FindVisibleTarget()){
			playerVisibleTimer += Time.deltaTime;
		}else{
			playerVisibleTimer -= Time.deltaTime;
		}
		playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpot);
		if(playerVisibleTimer >= timeToSpot){
			//do something
		}
	}
	void GoToNextPoint(){
		int waypointIndex=0;
		if(waypoints.Length == 0) return;

		agent.SetDestination(waypoints[waypointIndex]);
		waypointIndex = (waypointIndex + 1) % waypoints.Length;
	}
	public float getPlayerVisibleTimer(){
		return playerVisibleTimer;
	}
    #region IEnumerator script
    /*
	IEnumerator FollowPath(Vector3[] waypoints){
		int waypointIndex = 0;
		Vector3 targetWaypoint = waypoints[waypointIndex];
        transform.LookAt(targetWaypoint);
		agent.SetDestination(targetWaypoint);
		while (true)
		{
            agent.SetDestination(targetWaypoint);
			currentWaypoint = targetWaypoint;
			if(!FindVisibleTarget()){
				if( transform.position == targetWaypoint){
					waypointIndex= (waypointIndex + 1) % waypoints.Length;
					targetWaypoint = waypoints[waypointIndex];
					yield return new WaitForSeconds(waitTime);
					yield return StartCoroutine(TurnToFace(targetWaypoint));
				}
			}
			yield return null;
		}
	}
	 
	IEnumerator TurnToFace(Vector3 lookTarget){
		Vector3 dirLookTarget = (lookTarget - transform.position).normalized;
		float targetAngle = 90- Mathf.Atan2(dirLookTarget.z, dirLookTarget.x)*Mathf.Rad2Deg;
		while(Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle))>0.05f){
			float angle= Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
			transform.eulerAngles = Vector3.up * angle;
			yield return null;
		}
	}
	*/
    #endregion

    #region field of view 
    private void OnDrawGizmos() {
		Vector3 startPos = pathHolder.GetChild(0).position;
		Vector3 prevPos = startPos;
		foreach (Transform waypoint in pathHolder)
		{
			Gizmos.DrawSphere(waypoint.position, .2f);
			Gizmos.DrawLine(prevPos, waypoint.position);
			prevPos = waypoint.position;
		}
		Gizmos.DrawLine(prevPos, startPos);
	}
	public Vector3 DirFromAngle(float angleInDegree, bool angleIsGlobal){
		if(!angleIsGlobal){
			angleInDegree += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegree * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
	}
	bool FindVisibleTarget(){
		visibleTarget.Clear();
		Collider[] targetPlayer = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
		for (int i = 0; i < targetPlayer.Length; i++)
		{
			target = targetPlayer[i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if(Vector3.Angle(transform.forward, dirToTarget)< viewAngle/2){
				float dstToTarget = Vector3.Distance(transform.position, target.position);
				if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacles)){
					visibleTarget.Add(target);
					return true;
				}
			}
		}
		return false;
	}
	#endregion

}
