using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesCommand : MonoBehaviour {

    public virtual void Execute() { }
    public void Next()
    {
        //set up character lines display mode
        LinesCommandManager.instance.Next2();
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
