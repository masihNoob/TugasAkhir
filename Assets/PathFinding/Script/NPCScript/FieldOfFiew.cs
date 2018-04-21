using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfFiew : MonoBehaviour {
    #region field of view variable
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    Transform target;
    Vector3 currentWaypoint;
    public LayerMask obstacles;
    public LayerMask targetMask;
    public List<Transform> visibleTarget = new List<Transform>();
    public Transform pathHolder;
    #endregion


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #region field of view 
    private void OnDrawGizmos()
    {
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
    public Vector3 DirFromAngle(float angleInDegree, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegree += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegree * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
    }
    bool FindVisibleTarget()
    {
        visibleTarget.Clear();
        Collider[] targetPlayer = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetPlayer.Length; i++)
        {
            target = targetPlayer[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacles))
                {
                    visibleTarget.Add(target);
                    return true;
                }
            }
        }
        return false;
    }
    #endregion

}
