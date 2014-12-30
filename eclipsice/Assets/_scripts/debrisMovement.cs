using UnityEngine;
using System.Collections;

public class debrisMovement : MonoBehaviour
{
	public float speed;
	public Vector3 origin = new Vector3(0, 0, 0);
	public Vector3 destination, start;
	public int count;
	
	//calls at the beginning of the game
	void Start ()
	{
		speed = 0.007f; //initializes speed to 0.008
		float x, y;
		if (Random.Range(1, 10) > 5) //puts it outside the horizontal range
		{
			y = Random.Range (-3, 3);
			//ramdomizes which edge of the camera the cube spawns
			if (Random.Range(1, 10) > 5) x = -8.5f;
			else x = 8.5f;
		}
		else //puts it outside the vertical range
		{
			x = Random.Range (-8.5f, 8.5f);
			//ramdomizes which edge of the camera the cube spawns
			if (Random.Range(1, 10) > 5) y = -3;
			else y = 3;
		}
		start = new Vector3 (x, y, 0); //generates a random postion out side the view of the camera
		transform.localPosition = start;
		destination = new Vector3(-1 * transform.localPosition.x, -1 *  transform.localPosition.y, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.localPosition = Vector3.Lerp(transform.localPosition, destination, speed);
//		if (classic_controller.pause = true)
//			Time.timeScale = 0.0f;
//		else Time.timeScale = 1.0f;
	}

	//FOR TESTING PURPOSES **REMEMBER TO COMMENTING IT OUT DURING BUILDING THE PROJECT!!**
//	void OnMouseDown () //detects mouse clicks and touches
//	{
//		classic_controller.count++;
//		Destroy (gameObject);
//	}
}
