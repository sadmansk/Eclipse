using System;
using UnityEngine;
using System.Collections;

public class survival_controller : MonoBehaviour //parent script that controls the entire game as well
{
	private int interval, startTime; //interval stores how long for the next debris to spawn
	private float deltaTime, start; // deltaTime stores how much the interval should change
	public GUIText timeSec; //contains this parent component since this script is static throughout the game
	public Transform iceCube, scoreScreen;
	public static bool spawn;
	public static float score;

	void Start()
	{
		startTime = (int)(Time.time * 1000); //Time.time * 1000 converts the time from seconds to milliseconds
		setText ();
		spawn = true;
		interval = 600; //interval between each object spawn starts from 1000 milliseconds
		deltaTime = 0.99f;
		start = Time.time;
		score = Time.time - start;
	}
	// Update is called once per frame
	void Update ()
	{
		if (spawn)
		{
			int time = (int)(Time.time * 1000) - startTime;//converts time to milliseconds
			if (time >= interval) //once time crosses the interval
			{
				Instantiate(iceCube);
//				print (Time.time);
//				print (interval);
				if (interval >= 250) //makes sure that the minimum time reached is 100
					interval = (int)(interval * deltaTime); //the interval decreases by 20
				startTime = (int)(Time.time * 1000); //makes sure that the new 'time' is 0 when the loop ends
			}
			score = Time.time - start;
			setText ();
		}
		//gets touch input
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );
			RaycastHit hit;
			
			if ( Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "iceCube")
			{
				hit.collider.gameObject.SetActive(false);
			}
		}
	}

	void setText() //sets the text for the GUIText components
	{
		timeSec.text = (Math.Round(score, 3)).ToString() + "s";
	}
}