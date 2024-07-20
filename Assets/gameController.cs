using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour 
{
	public GameObject enemyPrefab;
	public playerLogic player;
	public Text gameText;
	public float enemyCountDown = 2.0f;
	public float minimumEnemyCountdown = 1.0f;
	private float enemyTimer;
	private float gameTimer;
	private bool isGameOver;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("r"))
		{
			SceneManager.LoadScene ("GameScene");
		}

		if(player!=null)
		{
			gameTimer += Time.deltaTime;
			gameText.text = "Time: " + Mathf.Floor(gameTimer);
		}
		else
		{
			if(!isGameOver)
			{
				isGameOver = true;
				gameText.text += "\nGame over, press R to Restart!";
			}
		}


		enemyTimer -= Time.deltaTime;
		if(enemyTimer<=0 && player!= null)
		{
			enemyTimer = enemyCountDown;

			enemyCountDown *= 0.9f;

			if(enemyCountDown < minimumEnemyCountdown)
			{
				enemyCountDown = minimumEnemyCountdown;
			}

			Vector3[] spawnPositions = new Vector3[] 
			{
				new Vector3(19,10,0),
				new Vector3(19,-10,0),
				new Vector3(-19,10,0),
				new Vector3(-19,-10,0)				
			};

			foreach(Vector3 spawnPosition in spawnPositions)
			{
				GameObject enemyObject = Instantiate (enemyPrefab);
				enemyObject.transform.position = spawnPosition;
				enemyObject.transform.SetParent (this.transform);

				enemyLogic enemy = enemyObject.GetComponent<enemyLogic> ();
				enemy.moveEnemyDir = (player.transform.position - spawnPosition).normalized;

			}
		}
		
	}
}
