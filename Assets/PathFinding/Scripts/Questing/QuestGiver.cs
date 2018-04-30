using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : DialogueTrigger {

	public bool AssignedQuest {get; set;}
	public bool Helped { get; set; }

	[SerializeField]
	private GameObject quests;
	[SerializeField]
	private string questType;
    private Quest Quest { get; set; }
	protected override void OnTriggerStay(Collider other) 
	{
        base.OnTriggerStay(other);
		if(other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F)){
            if (!AssignedQuest && !Helped)
            {
                AssignQuest();
            }
            else if (AssignedQuest && !Helped)
            {
                CheckQuest();
            }
            else
            {
                DialogueSystem.Instance.AddNewDialogue(new string[] { "thanks you for that" }, name);
            }
		}
		
	}
	void AssignQuest()
	{
		AssignedQuest = true;
		Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
	}
	void CheckQuest()
	{
		if(Quest.IsCompleted)
		{
			Quest.GiveReward();
			Helped = true;
			AssignedQuest = false;
			DialogueSystem.Instance.AddNewDialogue(new string [] {"thanks you"}, name);
		}
		else
		{
            DialogueSystem.Instance.AddNewDialogue(new string[] { "please find all keys", "you only can release me with the keys" }, name);
		}
	}
}
