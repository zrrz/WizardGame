using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

//	public Vector3[] path;

	public float speed;

	void Start () {
		StartCoroutine(MoveOnPath());
	}
	
	void Update () {
		
	}

	IEnumerator MoveOnPath() {
		Vector3[] pathPos = iTweenPath.GetPath("EnemyPathPos");
		Vector3[] pathRot = iTweenPath.GetPath("EnemyPathRot");
		for(float timer = 0f; timer < 1f; timer += Time.deltaTime/speed) {
			Vector3 pointOnPath = iTween.PointOnPath(pathPos, timer);

			Vector3 dir = iTween.PointOnPath(pathPos, timer) - iTween.PointOnPath(pathRot, timer);
			Debug.DrawRay(transform.position, dir);
			dir.Normalize();

			float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90f);

//			Quaternion rotation = Quaternion.LookRotation(pointOnPath - transform.GetChild(0).position, transform.TransformDirection(Vector3.up));
//			transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

			transform.position = pointOnPath;
			yield return null;
		}
	}
}
