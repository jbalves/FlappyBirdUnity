using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdController : MonoBehaviour {

	[Header("Velocity")]
	public float flappyVelocity;

	[Header("FlappyBird states")]
	public bool isDead = false;

	[Header("Animation")]
	private Animator animator;
	private Rigidbody2D rigidBody2d;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rigidBody2d = GetComponent<Rigidbody2D> ();

		//Convertendo coordenadas de tela para o Mundo
		Vector3 startPos = Camera.main.ViewportToWorldPoint (new Vector3 (0.2f, 0.8f));

		startPos.z = 0f;
		transform.position = startPos;
	}
	
	// Update is called once per frame
	void Update () {

		if(isDead){
			return;
		}
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			FlappyWings ();
		}

		Vector3 angles = transform.eulerAngles;
		angles.z = Mathf.Clamp(rigidBody2d.velocity.y * 4f, -90f, 45f);
		transform.eulerAngles = angles;
	}

	//Faz o Flappy Bird bater asas
	void FlappyWings() {
		//Anima o Flappy Bird
		animator.SetTrigger ("Flappy");
		//Movimenta o Flappy Bird
		rigidBody2d.velocity = Vector2.up * flappyVelocity;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		//Se for pipe então mata o Flappy Bird
		if(collision.collider.CompareTag("Pipe")){
			//Dead
			isDead = true;
			//Deixa de colidir
			GetComponent<Collider2D> ().isTrigger = true;
		}
	}
}
