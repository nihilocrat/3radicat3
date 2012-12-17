using UnityEngine;
using System.Collections;

public class AlphaFade : MonoBehaviour {
	
	public float duration = 1.0f;
	public Color destinationColor;
	
	private Color originalColor;
	private float beginTime;
	
	// Use this for initialization
	void Start () {
		originalColor = renderer.material.GetColor("_TintColor");
		//destinationColor = originalColor;
		//destinationColor.a = minAlpha;
		
		beginTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float t = (Time.time - beginTime) / duration;
		
		renderer.material.SetColor("_TintColor", Color.Lerp(originalColor, destinationColor, t));
	}
}
