using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseQuest : Quest {

	// Use this for initialization
	void Start () {
		QuestName = "get keys";
		Description = "kumpulkan semua kunci untuk membebaskan anjing";
		//ItemReward = 
		ExperienceReward = 100;

		Goals.Add(new KillGoal(this, 0, "find all keys", false, 0, 3));
		Goals.ForEach(g=> g.Init());
	}
	
}
