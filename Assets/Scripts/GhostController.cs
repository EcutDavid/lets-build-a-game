using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
	public float speed;
    public Transform mainCameraPos;

	private Animator animator;
	private Vector3 initialScale;
	private Vector3 flipXScale;
    


	void Start () {
		animator = GetComponent<Animator> ();
		initialScale = transform.localScale;
		flipXScale = transform.localScale - new Vector3(transform.localScale.x * 2f, 0, 0);
	}
	
	void Update () {
		var spriteRenderer = GetComponent<SpriteRenderer> ();
		var body = GetComponent<Rigidbody2D> ();
		var particles = GetComponent<ParticleSystem> ();
		particles.Stop ();
		animator.SetBool ("isMove", false);
		animator.SetBool ("isWind", false);
		if(Input.GetKey(KeyCode.RightArrow)) {
			transform.localScale = initialScale;
			body.transform.position = body.transform.position + Vector3.right * Time.deltaTime * speed;
			animator.SetBool ("isMove", true);
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			body.transform.position = body.transform.position - Vector3.right * Time.deltaTime * speed;
			animator.SetBool ("isMove", true);
			transform.localScale = flipXScale;
		}
		if(Input.GetKey(KeyCode.Space)) {
            //FIXME: do not keep the force increasing
			body.AddForce (transform.up  * 10f);
		}
		if(Input.GetKey(KeyCode.W)) {
			animator.SetBool ("isWind", true);
			particles.Play ();
		}

        //let the main camera follow ghost.
        Vector3 mainCameraOffset = new Vector3(0, 2.5f, -10f);
        mainCameraPos.position = body.transform.position + mainCameraOffset;

        //make the characters not fall to the ground. #This code could be used in other GameObject
        body.transform.rotation = Quaternion.Euler(0, 0, 0);

    }
}
