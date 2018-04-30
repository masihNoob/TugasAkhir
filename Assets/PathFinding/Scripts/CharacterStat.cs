using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour {
	public List<BaseStat> stats = new List<BaseStat>();
	// Use this for initialization
	void Start () {
		stats.Add(new BaseStat(4, "speed", "movement speed"));
		stats.Add(new BaseStat(2, "life", "can respawn"));
	}
	//stat player bertambah jika ada item
	public void AddStatBonus(List<BaseStat> statBonuses)
	{
		foreach (BaseStat statBonus in statBonuses)
		{
            stats.Find(x => x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
		}
	}
	public void RemoveStatBonus(List<BaseStat> statBonuses)
	{
		foreach (BaseStat statBonus in statBonuses)
		{
            stats.Find(x => x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
		}
	}
}
