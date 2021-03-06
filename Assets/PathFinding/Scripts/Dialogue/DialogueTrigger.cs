﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (BoxCollider))]
public class DialogueTrigger : MonoBehaviour {

	public string[] dialogue;
	public string nameNpc;
	private float scaleX, scaleY, scaleZ;

	BoxCollider box;
	private void Start() {
		box = GetComponent<BoxCollider>();

        scaleX = box.size.x;
        scaleY = box.size.y;
        scaleZ = box.size.z;

		box.size = new Vector3(scaleX, scaleY, scaleZ)*1.5f;
		box.isTrigger = true;

		//Debug.Log(box.size);
	}
	protected virtual void OnTriggerStay(Collider other) 
	{
		if(other.gameObject.CompareTag ("Player") && Input.GetKeyDown(KeyCode.F))
		{
			DialogueSystem.Instance.AddNewDialogue(dialogue, nameNpc);
		}
	}
}
