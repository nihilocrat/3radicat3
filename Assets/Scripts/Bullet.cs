using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{	
	public GameObject boomPrefab;
	public float speed = 100.0f;
	public bool penetrates = false;
	public Material splitMaterial;
	
	private bool hasSplit = false;
	private DestroyTimer destroyer;
	
	void Start ()
	{
		rigidbody.AddForce(transform.forward * speed);
		destroyer = GetComponent<DestroyTimer>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<Destroyable>() != null)
		{
			other.gameObject.SendMessage("OnKill");
		}
		
		if(!penetrates)
		{
			if(boomPrefab != null)
			{
				Instantiate(boomPrefab, transform.position, transform.rotation);
			}
			Destroy(gameObject);
		}
	}
	
	void OnSplit()
	{
		Debug.Log("got split command!");
		if(hasSplit == false)
		{
			var clone = Instantiate(this.gameObject, transform.position, transform.rotation) as GameObject;
			
			// pick a random thingie to point at
			var cities = GameObject.FindGameObjectsWithTag("City");
			var index = Random.Range(0, cities.Length);
			clone.transform.LookAt(cities[index].transform.position);
			
			clone.renderer.sharedMaterial = splitMaterial;
			renderer.sharedMaterial = splitMaterial;
			
			hasSplit = true;
		}
	}
}
