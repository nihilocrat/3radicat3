using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	public Transform[] weapons;
	public GameObject currentWeapon;
	public int currentIndex = 0;
	
	// Use this for initialization
	void Start () {
		currentWeapon = weapons[0].gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=1;i<=weapons.Length;i++)
		{
			if(Input.GetButtonDown("Fire" + i))
			{
				var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				worldPos.z = 0.0f;
				weapons[i-1].SendMessage("FireAt", worldPos);
			}
		}
		
		if(Input.GetMouseButtonDown(0))
		{
			var hitRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(hitRay, out hit))
			{
				if(hit.collider.gameObject.CompareTag("Player"))
				{
					hit.collider.gameObject.SendMessage("OnSplit");
				}
			}
		}
		
		/*
		if(Input.GetButtonDown("Fire1"))
		{
			var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPos.z = 0.0f;
			currentWeapon.SendMessage("FireAt", worldPos);
		}
		if(Input.GetButtonDown("Horizontal"))
		{
			if(Input.GetAxis("Horizontal") > 0.0f)
			{
				currentIndex += 1;
			}
			else
			{
				currentIndex -= 1;
			}
			
			if(currentIndex < 0)
				currentIndex = weapons.Length - 1;
			if(currentIndex >= weapons.Length)
				currentIndex = 0;
			
			currentWeapon = weapons[currentIndex].gameObject;
		}
		*/
		
	}
}
