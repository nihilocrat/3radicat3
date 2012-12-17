using UnityEngine;
using System.Collections;

public class MissileLauncher : MonoBehaviour
{	
	public GameObject missilePrefab;
	public int maxAmmo = 5;
	public float rate = 1.0f;
	public float reloadRate = 0.5f;
	public float missileSpeed = 100.0f;
	
	public int ammo
	{
		get;
		private set;
	}
	
	private Transform muzzle;
	private float reloadCooldown;
	
	// Use this for initialization
	void Start () {
		muzzle = transform.Find("muzzle");
		if(muzzle == null)
		{
			muzzle = transform;
		}
		
		ammo = maxAmmo;
		reloadCooldown = reloadRate;
	}
	
	void FixedUpdate()
	{
		if(ammo < maxAmmo)
		{
			if(reloadCooldown <= 0.0f)
			{
				ammo += 1;
				reloadCooldown += reloadRate;
			}
			else
			{
				reloadCooldown -= Time.fixedDeltaTime;
			}
		}
	}
	
	void FireAt(Vector3 aimPos)
	{
		if(ammo <= 0)
			return;
		
		aimPos.z = 0.0f;
		
		var missile = Instantiate(missilePrefab, muzzle.position, muzzle.rotation) as GameObject;
		Physics.IgnoreCollision(collider, missile.collider);
		missile.transform.LookAt(aimPos);
		
		var bullet = missile.GetComponent<Bullet>();
		bullet.speed = missileSpeed;
		
		if(missile.GetComponent<DestroyTimer>() != null)
		{
			StartCoroutine(SetTimer(aimPos, missile));
		}
		
		ammo -= 1;
	}
	
	IEnumerator SetTimer(Vector3 aimPos, GameObject missile)
	{
		yield return new WaitForSeconds(0.1f);
		if(missile == null)
		{
			yield return null;
		}
		else
		{
			var distance = (aimPos - muzzle.position).magnitude;
			var destroyer = missile.GetComponent<DestroyTimer>();
			destroyer.time = distance / missile.rigidbody.velocity.magnitude;
		}
	}
}
