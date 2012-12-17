using UnityEngine;
using System.Collections;

public class AIMissileDefender : MonoBehaviour
{
	private const float updateRate = 0.8f;
	private float lastUpdate = 0.0f;
	
	void Start () {
	
	}
	
	void FixedUpdate ()
	{
		if(Time.fixedTime - lastUpdate >= updateRate)
		{
			var aimPoint = (Random.insideUnitSphere * 12.0f);
			aimPoint.y *= 0.1f;
			BroadcastMessage("FireAt", aimPoint);
			
			lastUpdate = Time.fixedTime;
		}
	}
}
