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

	public Gradient gradient;

	void Start () {
//		spriteRenderers = new List<SpriteRenderer>(FindObjectsOfType<SpriteRenderer>());
//		originalColors = new Dictionary<SpriteRenderer, Color>();
//		foreach(SpriteRenderer sr in spriteRenderers) {
//			originalColors.Add(sr, sr.color);
//		}
		originalColor = light.color;
	}
	
	void Update () {
		light.color = gradient.Evaluate(time/dayLength);
		time += Time.deltaTime;
		if(time > dayLength)
			time = 0f;
		
//		time = Mathf.PingPong(Time.time, dayLength);

//		Color col = originalColor;
//		col.r -= time/11f;
//		col.g -= time/11f;
//		col.b -= time/11f;
//		light.color = col;

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
