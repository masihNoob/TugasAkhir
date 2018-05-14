using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal 
{
	public int ReqId { get; set; }

	public CollectionGoal(Quest _quest, int _reqId, string _description, bool _isCompleted, int _currentAmount, int _requiredAmount)
	{
		this.Quest = _quest;
		this.ReqId = _reqId;
		this.Description = _description;
		this.IsCompleted = _isCompleted;
		this.CurrentAmount = _currentAmount;
		this.RequiredAmount = _requiredAmount;
	}
	public override void Init()
	{
		base.Init();
		//CombatEvent
	}
	void FoundKey(Keys _key)
	{
		if(_key.ID == this.ReqId)
		{
			Debug.Log("found key");
			this.CurrentAmount++;
			Evaluate();
		}
	}
}
