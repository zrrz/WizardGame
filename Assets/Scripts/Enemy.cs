using UnityEngine;
using System.Collections;
//using System;

public class Enemy : MonoBehaviour {

	public float speed = 4f;
	public GameObject particlePrefab;
	public Transform attackPoint;

	Rigidbody2D rigidbody;
	Animator animator;

	Vector3 moveDirection;

	bool dead = false;

	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void Update () {
		if(!dead)
			rigidbody.velocity = moveDirection*speed;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.transform.GetComponent<Tower>() != null) {
			animator.SetBool("Attack", true);
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
		rigidbody.AddForce(Vector2.up * Random.Range(200f, 600f));
		rigidbody.AddTorque(Random.Range(-100f, 100f));
//		rigidbody.isKinematic = true;
		rigidbody.gravityScale = 2f;
		dead = true;
		//Do anim BS
	}
}
