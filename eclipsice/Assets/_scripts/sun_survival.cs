using UnityEngine;
using System.Collections;

public class sun_survival : MonoBehaviour
{
	public Transform scoreScreen;
	
	void DestroySelf ()
	{
		//destroys all the other instances of the ice cubes
		GameObject[] killEmAll;
		killEmAll = GameObject.FindGameObjectsWithTag("iceCube");
		for(int i = 0; i < killEmAll.Length; i++)
		{
			Destroy(killEmAll[i].gameObject);
		}
		Destroy (this.gameObject);
		Handheld.Vibrate(); //vibrates the phone
		survival_controller.spawn = false;
		Instantiate (scoreScreen);
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "iceCube");
		{
			Destroy (other.gameObject);
			transform.localScale = transform.localScale * 1.4F; //increases the size of the sphere
			SphereCollider myCollider = transform.GetComponent<SphereCollider>();
			myCollider.radius = (transform.localScale.x - 0.25f) / (2.0f * transform.localScale.x);
		}
		//if the radius crosses the threshold, object gets destroyed
		if (this.transform.localScale.x > 2.0f)
			DestroySelf();
	}
}
