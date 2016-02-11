using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {

	public float speed;

	public GameObject particle;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void SetPositions(List<Vector3> positions) {
		StartCoroutine(Move(positions));
	}

	IEnumerator Move(List<Vector3> positions) {
		for(int i = 0; i < positions.Count; i++) {
			
//			RaycastHit2D hit = Physics2D.Raycast((Vector2)Camera.main.ScreenToWorldPoint(positions[i]), Vector2.zero); 
//			print(Camera.main.ScreenToWorldPoint(positions[i]));
			Vector3 pos =  Camera.main.ScreenToWorldPoint(positions[i]);
			pos.z = 0f;
			transform.position = pos;


			yield return new WaitForSeconds(speed);
		}
		Destroy(gameObject, speed);
		Instantiate(particle, transform.position, Quaternion.identity);
	}
}
