using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandDialogue : LinesCommand
{
    private Text textDisp;
    private string lines;
    private GameObject linesTrans;
    private GameObject character;

    public CommandDialogue(string lines, GameObject character, GameObject linesTrans)
    {
        //character.
        this.textDisp = character.GetComponent<Text>();
        this.lines = lines;
        this.linesTrans = linesTrans;
        this.character = character;
    }

    public override void Execute()
    {
        textDisp.text = lines;
        Next();
    }
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
