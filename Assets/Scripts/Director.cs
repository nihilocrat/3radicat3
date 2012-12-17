using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	
	public static Director singleton;
	public GUIText victoryText;
	
	void Awake()
	{
		singleton = this;
	}
	
	void Start ()
	{
		
	}
	
	public void OnCityDestroyed()
	{
		var cityCount = GameObject.FindGameObjectsWithTag("City").Length - 1;
		
		Debug.Log ("city destroyed, remaining: " + cityCount);
		
		if(cityCount <= 0)
		{
			OnVictory();
		}
	}
	
	void OnVictory()
	{
		StartCoroutine(doVictory());
	}
	
	IEnumerator doVictory()
	{
		victoryText.gameObject.SetActive(true);
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel(0);
	}
}
