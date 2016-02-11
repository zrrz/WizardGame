using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	bool clickStarted = false;

	List<Vector3> mousePositions;

	public GameObject projectilePrefab;

	void Start () {
		mousePositions = new List<Vector3>();
	}
	
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			clickStarted = true;
			mousePositions.Clear();
		}
		if(clickStarted) {
			mousePositions.Add(Input.mousePosition);
		}
		if(Input.GetButtonUp("Fire1")) {
			clickStarted = false;
			FireProjectile();
		}
	}

	public void FireProjectile() {
		GameObject projectile = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
		projectile.GetComponent<Projectile>().SetPositions(mousePositions);
	}
}
