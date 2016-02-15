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
//			Vector3 pos =  Camera.main.ScreenToWorldPoint(positions[i]);
//			pos.z = 0f;
			Vector3 position = transform.position;
			for(float timer = 0; timer < speed; timer += Time.deltaTime) {
				transform.position = Vector3.Lerp(position, positions[i], timer);
				yield return null;
			}
			transform.position = Vector3.Lerp(position, positions[i], 1f);
			yield return null;
		}
		Destroy(gameObject, speed);
		Instantiate(particle, transform.position, Quaternion.identity);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.transform.GetComponent<Enemy>() != null) {
			col.transform.GetComponent<Enemy>().Die();
		}
	}
}
