using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject enemyPrefab;
	public float enemySpawnCD = 2.0f;
	public Transform[] spawnPoints;

	void Start () {
		StartCoroutine(SpawnEnemy());
	}
	
	void Update () {
	
	}

	IEnumerator SpawnEnemy() {
		while(true) {
			if(spawnPoints.Length == 0) {
				Debug.LogError("No spawn points", this);
				yield break;
			}
			int spawnPoint = Random.Range(0, spawnPoints.Length);

			Enemy enemy =  ((GameObject)Instantiate(enemyPrefab, spawnPoints[spawnPoint].position, Quaternion.identity)).GetComponent<Enemy>();
			if(FindObjectOfType<Tower>().transform.position.x > spawnPoints[spawnPoint].position.x)
				enemy.SetDirection(Vector3.right);
			else
				enemy.SetDirection(Vector3.left);
			yield return new WaitForSeconds(enemySpawnCD);
		}
	}
}
