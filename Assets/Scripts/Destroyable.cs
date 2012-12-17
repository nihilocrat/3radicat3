using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour
{
	public GameObject boom;
	
	void OnTriggerEnter(Collider other)
	{
		//Destroy(gameObject);
	}
	
	void OnKill()
	{
		Director.singleton.OnCityDestroyed();
		if(boom != null)
		{
			Instantiate(boom, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}
}
