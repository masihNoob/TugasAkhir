using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseQuest : Quest {

	// Use this for initialization
	void Start () {
		QuestName = "Release Quest";
		Description = "kumpulkan semua kunci untuk membebaskan burung";
		//ItemReward = 
		ExperienceReward = 100;

		Goals.Add(new CollectionGoal(this, 0, "find all keys", false, 0, 1));
		Goals.ForEach(g=> g.Init());
	}
	
}
