using UnityEngine;
using System.Collections;

public class classic_controller : MonoBehaviour //parent script that controls the entire game as well
{
	private int interval, startTime; //interval stores how long for the next debris to spawn
	private float deltaTime; // deltaTime stores how much the interval should change
	public static int count;
	public GUIText countText; //contains this parent component since this script is static throughout the game
	public Transform iceCube, pausePlane;
	public static bool spawn, pause;

	void Start()
	{
		startTime = (int)(Time.time * 1000); //Time.time * 1000 converts the time from seconds to milliseconds
		setText ();
		spawn = true;
		interval = 600; //interval between each object spawn starts from 1000 milliseconds
		count = 0;
		deltaTime = 0.99f;
		pause = false;
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown("escape"))
		{
			pause = !pause; //toggles the pause boolean
		}

		if (pause && spawn)
		{
			Time.timeScale = 0.0f;
			pausePlane.gameObject.SetActive (true);
		}
		else
		{
			Time.timeScale = 1.0f;
			pausePlane.gameObject.SetActive(false);
		}

		//rotates the background
		transform.Rotate (new Vector3(0.003f, 0.003f, 0.003f));


		if (spawn)
		{
			int time = (int)(Time.time * 1000) - startTime;//converts time to milliseconds
			if (time >= interval) //once time crosses the interval
			{
				Instantiate(iceCube);
				if (interval >= 250) //makes sure that the minimum time reached is 100
					interval = (int)(interval * deltaTime); //the interval decreases by 20
				startTime = (int)(Time.time * 1000); //makes sure that the new 'time' is 0 when the loop ends
			}
			setText ();
		}
		//gets touch input
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );
			RaycastHit hit;
			
			if ( Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "iceCube")
			{
				count++;
				hit.collider.gameObject.SetActive(false);
			}
		}
	}

	void setText() //sets the text for the GUIText components
	{
		countText.text = "" + count;
	}
}