using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
	public Item PotionLog;
	// Use this for initialization
	void Start () {
		PotionLog = new Item(new List<BaseStat>(), "potion_log", "drink this", "drink", "log potion", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
