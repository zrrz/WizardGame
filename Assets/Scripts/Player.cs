using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	bool clickStarted = false;

	List<Vector3> mousePositions;

	public GameObject projectilePrefab;

	public float pathDistance = 0.3f;

	void Start () {
		mousePositions = new List<Vector3>();
	}
	
	void Update () {
		if(clickStarted) {
			Vector3 pos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.z = 0f;
			mousePositions.Add(pos);
		}
	}

	public void FireProjectile() {
		for(int i = 0; i < mousePositions.Count - 1; i++) {
			while(i < mousePositions.Count - 1 && Vector3.Distance(mousePositions[i], mousePositions[i+1]) < pathDistance) {
				mousePositions.RemoveAt(i+1);
			}
		}
		for(int i = 0; i < mousePositions.Count - 1; i++) {
			Debug.DrawLine(mousePositions[i], mousePositions[i+1], Color.red, 3.0f);
		}
		GameObject projectile = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
		projectile.GetComponent<Projectile>().SetPositions(mousePositions);
	}

	void OnMouseDown() {
		clickStarted = true;
		mousePositions.Clear();
	}

	void OnMouseUp() {
		clickStarted = false;
		FireProjectile();
	}
}
