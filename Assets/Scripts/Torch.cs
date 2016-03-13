using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

	public float flickerAmount = 1.0f;
	[Range(0f, 1f)]
	public float flickerSpeed = 0.1f;
	public Color color1 = Color.red;
	public Color color2 = new Color(1.0f, 0.6f, 0.15f, 1.0f);

	float originalIntensity;

	public Light lightObj;

	void Start () {
		originalIntensity = lightObj.intensity;
		StartCoroutine(Flicker());
	}
	
	IEnumerator Flicker() {
		while(true) {
			lightObj.intensity = originalIntensity + Random.Range(-flickerAmount, flickerAmount);
			Color targetColor = Color.Lerp(color1, color2, Random.Range(0.0f, 1.0f));
			Color previousColor = lightObj.color;
			for(float time = 0f; time <= 1f; time += Time.deltaTime/flickerSpeed) {
				lightObj.color = Color.Lerp(previousColor, targetColor, time);
				yield return null;
			}
//			yield return new WaitForSeconds(flickerSpeed);
		}
	}
}
