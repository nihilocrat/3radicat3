using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour
{	
	public float time = 1.0f;
	public GameObject boom;
	
	private float startTime;
	
	// Use this for initialization
	void Start ()
	{
		startTime = Time.fixedTime;
	}
	
	void FixedUpdate ()
	{
		if(Time.fixedTime - startTime >= time)
		{
			if(boom != null)
			{
				Instantiate(boom, transform.position, transform.rotation);
			}
			Destroy(gameObject);
		}
	}
}
