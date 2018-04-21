using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
public class NavigationLine : MonoBehaviour {

	// Use this for initialization
	public NavMeshAgent agent;
	private LineRenderer line;
	void Start () {
		line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(agent.hasPath){
			line.positionCount = agent.path.corners.Length;
			line.SetPositions(agent.path.corners);
			line.enabled =true;
		}else
		{
			line.enabled =false;
		}
	}
}
