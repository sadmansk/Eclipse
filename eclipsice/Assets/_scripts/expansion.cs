using UnityEngine;
using System.Collections;

public class expansion : MonoBehaviour
{
	public Vector3 expansionRate = new Vector3 (1,1,1);

	// Update is called once per frame
	void Update ()
	{
		//transform.localScale += expansionRate;
	}

	void OnTriggerEnter (Collider other)
	{
		transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);
	}
}
