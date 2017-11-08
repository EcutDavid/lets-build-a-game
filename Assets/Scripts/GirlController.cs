using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour {

    public string lines;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var body = GetComponent<Rigidbody2D>();


        //make the characters not fall to the ground. #This code could be used in other GameObject
        body.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
