using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

	public float speed = 4f;
	public GameObject particlePrefab;
	public Transform attackPoint;

	Rigidbody2D rigidbody;
	Animator animator;

	Vector3 moveDirection;

	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void Update () {
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
		Destroy(gameObject);
		//Do anim BS
	}
}
