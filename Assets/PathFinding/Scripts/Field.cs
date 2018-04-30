using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field :MonoBehaviour, IComponent {
    public List<BaseStat> Stats { get; set; }
	
    public void PerformAttack()
    {
        Debug.Log("perform action");
    }

}
