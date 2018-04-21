using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSystem : MonoBehaviour {

	public static DialogueSystem Instance { get; set;}
	public GameObject dialoguePanel;
    public string npcName;
	public List<string> dialogueLines = new List<string>();


	Button nextButton;
	Text dialogueText, nameText;
	int dialogueIndex;

	// Use this for initialization
	void Awake ()
	{
		nextButton = dialoguePanel.transform.Find("Next").GetComponent<Button>();
		dialogueText = dialoguePanel.transform.Find("Desc").GetComponent<Text>();
		nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();

		nextButton.onClick.AddListener(delegate {NextDialogue();});
		dialoguePanel.SetActive(false);

		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
            Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void AddNewDialogue(string[] lines, string npcName)
	{
		dialogueIndex = 0;
		this.npcName = npcName;
		dialogueLines = new List<string>(lines.Length);
		dialogueLines.AddRange(lines);

		CreateDialogue();
		Debug.Log(dialogueLines.Count);
	}

	public void CreateDialogue()
	{
		dialogueText.text = dialogueLines[dialogueIndex];
		nameText.text = npcName;
		dialoguePanel.SetActive(true);
	}

	void NextDialogue()
	{
		Debug.Log(dialogueIndex + " and " + dialogueLines.Count);
		if(dialogueIndex < dialogueLines.Count - 1)
		{
			dialogueIndex++;
			dialogueText.text = dialogueLines[dialogueIndex];
		}else
		{
			dialoguePanel.SetActive(false);
		}
	}
	
}
