using UnityEngine;
using System.Collections;

public class exitApplication : MonoBehaviour
{
	//when oblect is touched
	void OnMouseDown ()
	{
		//Application.Quit ();
		System.Diagnostics.Process.GetCurrentProcess().Kill();
	}
}
