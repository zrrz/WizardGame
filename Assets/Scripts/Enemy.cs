using UnityEngine;
using System.Collections;
//using System;

public class Enemy : MonoBehaviour {

	public float speed = 4f;
	public GameObject particlePrefab;
	public Transform attackPoint;

	Rigidbody2D rb;
	Animator animator;

	Vector3 moveDirection;

	bool dead = false;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void Update () {
		if(!dead)
			rb.velocity = moveDirection*speed;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.transform.GetComponent<Tower>() != null) {
			animator.SetBool("Attack", true);
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		if(col.transform.GetComponent<Tower>() != null) {
			animator.SetBool("Attack", false);
		}
	}

	public void SetDirection(Vector3 dir) {
		moveDirection = dir;
	}

	protected void Attack() {
		Instantiate(particlePrefab, attackPoint.position, Quaternion.identity);
		//Damage tower
	}

	public void Die() {
		Destroy(gameObject, 10f);
		rb.AddForce(Vector2.up * Random.Range(200f, 600f));
		rb.AddTorque(Random.Range(-100f, 100f));
//		rigidbody.isKinematic = true;
		rb.gravityScale = 2f;
		dead = true;
		//Do anim BS
	}
}
