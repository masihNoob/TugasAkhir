using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Quest : MonoBehaviour 
{
	public List<Goal> Goals { get; set; } = new List<Goal>();
	public string QuestName { get; set; }	
	public string Description { get; set; }
	public int ExperienceReward { get; set; }
	public Item ItemReward { get; set; }
	public bool IsCompleted { get; set; }

	public void CheckGoals()
	{
		IsCompleted = Goals.All(g => g.IsCompleted);
	}

    public void GiveReward()
    {
		
//		if(ItemReward != null) InventoryController.Instantiate.GiveReward
    }
}
