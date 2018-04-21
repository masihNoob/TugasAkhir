using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public string[] dialogue;
	public string nameNpc;

	private void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			DialogueSystem.Instance.AddNewDialogue(dialogue, nameNpc);
		}
	}
}
