using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(FieldOfFiew))]
public class FieldOfViewEditor : Editor {
	void OnSceneGUI(){
		FieldOfFiew fow = (FieldOfFiew)target;
		Handles.color = Color.white;
		Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);

		Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle/2f, false);
		Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle/2f, false);

		Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
		Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

		Handles.color = Color.red;
		foreach (Transform visible in fow.visibleTarget)
		{
			Handles.DrawLine(fow.transform.position, visible.position);
		}
	}
}
