using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable {
    public void Consume()
    {
        Debug.Log("you consume ");
    }

    public void Consume(CharacterStat stats)
    {
        Debug.Log("you consume stats");
    }
}
