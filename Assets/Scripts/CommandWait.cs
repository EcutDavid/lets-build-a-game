using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandWait : LinesCommand
{
    private float waitTime;
    private GameObject text;
    private GameObject lines;
    public CommandWait(float waitTime, GameObject text, GameObject lines)
    {
        this.waitTime = waitTime;
        this.text = text;
        this.lines = lines;
    }

    private float timeSeq;
    public override void Execute()
    {

        LinesCommandManager lineComWait = new LinesCommandManager();
        lineComWait.LineContainer(waitTime/*, text, lines*/);
        Next();
    }
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("it will not in to here");
	}
}
