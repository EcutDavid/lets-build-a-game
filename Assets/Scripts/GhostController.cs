using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
	public float speed;
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
			body.transform.position = body.transform.position + Vector3.right * Time.deltaTime * speed;
			animator.SetBool ("isMove", true);
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			body.transform.position = body.transform.position - Vector3.right * Time.deltaTime * speed;
			animator.SetBool ("isMove", true);
			transform.localScale = flipXScale;
		}
		if(Input.GetKey(KeyCode.Space)) {
			body.AddForce (transform.up  * 10f);
		}
		if(Input.GetKey(KeyCode.W)) {
			animator.SetBool ("isWind", true);
			particles.Play ();
		}
	}
}
