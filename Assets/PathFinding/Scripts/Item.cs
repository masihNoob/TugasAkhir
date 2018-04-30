using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
	public List<BaseStat> Stats { get; set; }
	public string ObjectSLug { get; set; }
	public string Description { get; set; }
	public string ActionName { get; set; }
	public string ItemName { get; set; }
	public bool ItemModifier { get; set; }

	public Item(List<BaseStat> _stats, string _objectSLug)
	{
		this.Stats = _stats;
		this.ObjectSLug = _objectSLug;
	}
	public Item(List<BaseStat> _stats, string _objectSLug, string _description, string _actionName, string _itemName, bool _itemModifier)
	{
		this.Stats = _stats;
		this.ObjectSLug = _objectSLug;
		this.Description = _description;
		this.ActionName = _actionName;
		this.ItemName = _itemName;
		this.ItemModifier = _itemModifier;
	}
}
