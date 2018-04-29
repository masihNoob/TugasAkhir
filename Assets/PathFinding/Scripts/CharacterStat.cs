using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour {
	public List<BaseStat> stats = new List<BaseStat>();
	// Use this for initialization
	void Start () {
		stats.Add(new BaseStat(4, "speed", "movement speed"));
		stats[0].AddStatBonus(new StatBonus(5));
		Debug.Log(stats[0].GetCalculateStatValues());
	}
	
}
