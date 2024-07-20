using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLogic : MonoBehaviour {

	public Camera gameCamera;
	public GameObject bulletPrefab;

	public float shootingCoolDown;
	public float shootingTimer;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 mousePosition = Input.mousePosition;
		Vector3 worldPosition = gameCamera.ScreenToWorldPoint (mousePosition);

		this.transform.position = new Vector3 (worldPosition.x, worldPosition.y, this.transform.position.z);

		shootingTimer -= Time.deltaTime;

		if (Input.GetMouseButtonDown (0) && shootingTimer<=0) 
		{
			shootingTimer = shootingCoolDown;
			Vector2[] directions = new Vector2[] 
			{
				Vector2.up,
				Vector2.down,
				Vector2.left,
				Vector2.right
			}; 

			foreach (Vector2 direction in directions) 
			{
				GameObject bulletObject = Instantiate (bulletPrefab);
				bulletObject.transform.position = this.transform.position;

				bulletLogic bullet = bulletObject.GetComponent<bulletLogic> ();
				bullet.movDir = direction;
			}


		}
	}
}
