using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject enemyPrefab;
	public float enemySpawnCD = 2.0f;
	public Transform[] spawnPoints;

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
		SpawnEnemy();
	}
	
	void Update () {
		
	}

	public static void CompleteTutorial() {
		instance.tutorialObject.SetActive(false);
		instance.StartCoroutine(instance.RepeatSpawn());
	}

	IEnumerator RepeatSpawn() {
		while(true) {
			if(spawnPoints.Length == 0) {
				Debug.LogError("No spawn points", this);
				yield break;
			}

			SpawnEnemy();

			yield return new WaitForSeconds(enemySpawnCD);
		}
	}

	void SpawnEnemy() {
		int spawnPoint = Random.Range(0, spawnPoints.Length);

		Enemy enemy =  ((GameObject)Instantiate(enemyPrefab, spawnPoints[spawnPoint].position, Quaternion.identity)).GetComponent<Enemy>();
		if(FindObjectOfType<Tower>().transform.position.x > spawnPoints[spawnPoint].position.x) {
			enemy.SetDirection(Vector3.right);
			Vector3 scale = enemy.transform.localScale;
			scale.x *= -1;
			enemy.transform.localScale = scale;
		} else {
			enemy.SetDirection(Vector3.left);
		}
	}
}
