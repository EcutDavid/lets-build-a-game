using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
	public Sprite standSprite;
	public Sprite moveSprite;
	public Sprite windSprite;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var spriteRenderer = GetComponent<SpriteRenderer> ();
		var body = GetComponent<Rigidbody2D> ();
		var particles = GetComponent<ParticleSystem> ();
		particles.Stop ();
		spriteRenderer.sprite = standSprite;
		if(Input.GetKey(KeyCode.RightArrow)) {
			spriteRenderer.sprite = moveSprite;
			body.transform.position = body.transform.position + Vector3.right * Time.deltaTime * speed;
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			body.transform.position = body.transform.position - Vector3.right * Time.deltaTime * speed;
		}
		if(Input.GetKey(KeyCode.Space)) {
			body.AddForce (transform.up  * 10f);
			particles.Play ();
			spriteRenderer.sprite = windSprite;
		}
	}
}
