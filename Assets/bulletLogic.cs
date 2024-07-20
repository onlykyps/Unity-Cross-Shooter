using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLogic : MonoBehaviour {

	public Vector2 movDir;
	public float speed;
	public float lifeTime = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.GetComponent<Rigidbody2D> ().velocity = movDir * speed;
		lifeTime -= Time.deltaTime;

		if (lifeTime <= 0)
		{Destroy  (this.gameObject);}
		
	}
}
