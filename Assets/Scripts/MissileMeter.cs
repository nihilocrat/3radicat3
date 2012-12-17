using UnityEngine;
using System.Collections;

public class MissileMeter : MonoBehaviour
{
	public MissileLauncher launcher;
	
	private int lastAmmo = 0;
	
	// Update is called once per frame
	void Update ()
	{
		if(launcher.ammo != lastAmmo)
		{
			for(int i=1; i <= launcher.maxAmmo; i++)
			{
				var bit = transform.Find(i.ToString());
				if(i <= launcher.ammo)
				{
					bit.gameObject.SetActive(true);
				}
				else
				{
					bit.gameObject.SetActive(false);
				}
			}
			
			lastAmmo = launcher.ammo;
		}
	}
}
