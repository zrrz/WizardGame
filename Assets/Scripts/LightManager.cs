using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightManager : MonoBehaviour {

//	List<SpriteRenderer> spriteRenderers;
//
//	Dictionary<SpriteRenderer, Color> originalColors;

	float time = 0f;

	public float dayLength = 10f;

	public Light light;
	Color originalColor;

	void Start () {
//		spriteRenderers = new List<SpriteRenderer>(FindObjectsOfType<SpriteRenderer>());
//		originalColors = new Dictionary<SpriteRenderer, Color>();
//		foreach(SpriteRenderer sr in spriteRenderers) {
//			originalColors.Add(sr, sr.color);
//		}
		originalColor = light.color;
	}
	
	void Update () {
		time = Mathf.PingPong(Time.time, dayLength);

		Color col = originalColor;
		col.r -= time/10f;
		col.g -= time/10f;
		col.b -= time/10f;
		light.color = col;

//		foreach(SpriteRenderer sr in spriteRenderers) {
//			Color col = originalColors[sr];
//			col.r -= time/15f;
//			col.g -= time/15f;
//			col.b -= time/15f;
////			originalColors[sr] = col;
//			sr.color = col;
//		}
	}
}
