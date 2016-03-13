using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudGenerator : MonoBehaviour {

	public GameObject[] cloudPrefabs;

	public Transform[] spawnPoints;

	public bool seedClouds = true;

	List<Cloud> clouds;

	[Range(0f,5f), SerializeField]
	float frequencyMin;
	[Range(0f,5f), SerializeField]
	float frequencyMax;

	[Range(0f,5f), SerializeField]
	float minSpeed;
	[Range(0f,5f), SerializeField]
	float maxSpeed;

	[Range(0f,5f), SerializeField]
	float minSize;
	[Range(0f,5f), SerializeField]
	float maxSize;

	[Range(0f,5f), SerializeField]
	float heightVariation;

	class Cloud {
		public GameObject cloudObj;
		public float speed;
		public enum Direction {Left, Right}
		public Direction direction;

		public float CalcDirection() {
			if(direction == Direction.Left)
				return -1f;
			else
				return 1f;
		}
	}

	IEnumerator Start () {
		clouds = new List<Cloud>();
		if(seedClouds)
			SeedClouds();

		while(true) {
			yield return new WaitForSeconds(Random.Range(frequencyMin, frequencyMax));
			SpawnCloud();
		}
	}
		
	void Update () {
		for(int i = 0; i < clouds.Count; i++) {
			if(clouds[i].cloudObj == null) {
				clouds.RemoveAt(i);
				i--;
			} else {
				float direction = clouds[i].CalcDirection() * clouds[i].speed * Time.deltaTime;
				clouds[i].cloudObj.transform.Translate(direction, 0f, 0f);
			}
		}
	}

	void SpawnCloud() {
		if(spawnPoints.Length == 0) {
			Debug.LogError("No spawn points", this);
			return;
		}
		Vector3 pos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
		pos.y += Random.Range(-heightVariation, heightVariation);

		if(cloudPrefabs.Length == 0) {
			Debug.LogError("No cloud prefabs", this);
			return;
		}
		GameObject cloudPrefab = cloudPrefabs[Random.Range(0, cloudPrefabs.Length)];

		GameObject cloudObj = (GameObject)Instantiate(cloudPrefab, pos, Quaternion.identity);
		Cloud cloud = new Cloud();
		cloud.cloudObj = cloudObj;
		cloud.speed = Random.Range(minSpeed, maxSpeed);
		cloud.direction = pos.x < FindObjectOfType<Tower>().transform.position.x ? Cloud.Direction.Right : Cloud.Direction.Left;
		Destroy(cloudObj, 40f);
		clouds.Add(cloud);
	}

	void SeedClouds() {
		float seedTime = 15f;

		int numClouds = Mathf.RoundToInt(seedTime/((frequencyMin+frequencyMax)/2f));

		for(int i = 0; i < numClouds; i++) {
			SpawnCloud();
			clouds[i].cloudObj.transform.Translate(clouds[i].CalcDirection() * clouds[i].speed * seedTime, 0f, 0f);
		}
	}
}
