using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour
{
	public Vector3 rotationRate = new Vector3(1, 1, 1);
	// Use this for initialization
	void Start ()
	{
			
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.Rotate (rotationRate);
		//print (Time.frameCount);
	}
}
