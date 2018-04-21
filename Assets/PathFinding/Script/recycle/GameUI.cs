using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
	Text teks;
	public GameObject _teks;
	Guard guard;
	void Start() {
		guard = Guard.FindObjectOfType<Guard>();
		teks = GameObject.Find("score").GetComponent<Text>();
	}
	void Update() {
		teks.text = guard.getPlayerVisibleTimer().ToString();
		DisableText();
	}
	void DisableText(){
		if(guard.getPlayerVisibleTimer() > 0)
			_teks.SetActive(true);
		else
			_teks.SetActive(false);
	}
}
