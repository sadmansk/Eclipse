using UnityEngine;
using System.Collections;

public class sun_classic : MonoBehaviour
{
	public Transform scoreScreen;

	void OnTriggerEnter (Collider other)
	{
		Destroy (other.gameObject);
		//other.transform.parent.gameObject.SetActive(false);
		//destroys all the other instances of the ice cubes
		GameObject[] killEmAll;
		killEmAll = GameObject.FindGameObjectsWithTag("iceCube");
		for(int i = 0; i < killEmAll.Length; i++)
		{
			Destroy(killEmAll[i].gameObject);
			killEmAll[i].gameObject.SetActive(false);
		}
		Handheld.Vibrate(); //vibrates the phone
		Instantiate (scoreScreen);
		classic_controller.spawn = false;
		Destroy (this.gameObject);
	}
}
