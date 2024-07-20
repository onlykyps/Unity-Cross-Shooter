using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour {

	public Vector3 moveEnemyDir;

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.GetComponent<Rigidbody2D> ().velocity = moveEnemyDir * speed;
		
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.GetComponent<bulletLogic> () != null) 
		{
			Destroy (this.gameObject);
			Destroy (c.gameObject);
		}

		if (c.gameObject.GetComponent<playerLogic> () != null) 
		{
			Destroy (c.gameObject);
		}
	}
}
