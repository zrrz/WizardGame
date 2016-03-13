using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject groundEnemyPrefab;
	public GameObject airEnemyPrefab;
	public float enemySpawnCD = 2.0f;
	public Transform[] groundSpawnPoints;
	public Transform[] airSpawnPoints;

//	enum GameState {
//		Tutorial, Play
//	}

//	GameState state = GameState.Tutorial;

	public GameObject tutorialObject;

	static GameManager instance;

	void Awake() {
		instance = this;
	}

	void Start () {
		SpawnGroundEnemy();
	}
	
	void Update () {
		
	}

	public static void CompleteTutorial() {
		instance.tutorialObject.SetActive(false);
		instance.StartCoroutine(instance.RepeatSpawn());
	}

	IEnumerator RepeatSpawn() {
		while(true) {
			int spawn = Random.Range(0, 2);
			if(spawn == 0)
				SpawnGroundEnemy();
			else if(spawn == 1)
				SpawnAirEnemy();

			yield return new WaitForSeconds(enemySpawnCD);
		}
	}

	void SpawnGroundEnemy() {
		if(groundSpawnPoints.Length == 0) {
			Debug.LogError("No ground spawn points", this);
			return;
		}
		int spawnPoint = Random.Range(0, groundSpawnPoints.Length);

		Enemy enemy =  ((GameObject)Instantiate(groundEnemyPrefab, groundSpawnPoints[spawnPoint].position, Quaternion.identity)).GetComponent<Enemy>();
		if(FindObjectOfType<Tower>().transform.position.x > groundSpawnPoints[spawnPoint].position.x) {
			enemy.SetDirection(Vector3.right);
			Vector3 scale = enemy.transform.localScale;
			scale.x *= -1;
			enemy.transform.localScale = scale;
		} else {
			enemy.SetDirection(Vector3.left);
		}
	}

	void SpawnAirEnemy() {
		if(airSpawnPoints.Length == 0) {
			Debug.LogError("No ground spawn points", this);
			return;
		}
		int spawnPoint = Random.Range(0, airSpawnPoints.Length);

		Enemy enemy =  ((GameObject)Instantiate(airEnemyPrefab, airSpawnPoints[spawnPoint].position + new Vector3(0f, Random.Range(-1f, 3f), 0f), Quaternion.identity)).GetComponent<Enemy>();
		if(FindObjectOfType<Tower>().transform.position.x > airSpawnPoints[spawnPoint].position.x) {
			enemy.SetDirection(Vector3.right);
			Vector3 scale = enemy.transform.localScale;
			scale.x *= -1;
			enemy.transform.localScale = scale;
		} else {
			enemy.SetDirection(Vector3.left);
		}
	}
}
