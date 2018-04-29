using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat
{
	public List<StatBonus> BaseAdditives { get; set; }
	public int BaseValue { get; set; }
	public string StatName { get; set; }
	public string StatDescription { get; set; }
	public int FinalValue { get; set; }


	public BaseStat(int _baseValue, string _statName, string _statDescription)
	{
		this.BaseAdditives = new List<StatBonus>();
		this.BaseValue = _baseValue;
		this.StatName = _statName;
		this.StatDescription = _statDescription;
	}
	//add stat
	public void AddStatBonus(StatBonus _statBonus)
	{
		this.BaseAdditives.Add(_statBonus);
	}
	//hapus stat
	public void RemoveStatBonus(StatBonus _statBonus)
	{
		this.BaseAdditives.Remove(_statBonus);
	}
	//get stat
	public int GetCalculateStatValues()
	{
		this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
		FinalValue += BaseValue;
		return FinalValue;
	}
}
