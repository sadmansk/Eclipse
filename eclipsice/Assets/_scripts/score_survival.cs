using UnityEngine;
using System;
//using System.IO;

public class score_survival : MonoBehaviour
{

	public GUIText prevHighScore, score;
	public float high;
	private String filePath = Application.persistentDataPath + "/survival_highscore.txt";
	// Use this for initialization
	void Start ()
	{
		print (filePath);
		//checks whether the file exists
		if (!System.IO.File.Exists(filePath)) //if the file does not exist
		{
			System.IO.FileStream fs =  new System.IO.FileStream(@filePath, 
			                                          System.IO.FileMode.OpenOrCreate, 
			                                          System.IO.FileAccess.ReadWrite, 
			                                          System.IO.FileShare.None);; //create the file
			high = 0.0f;
			using (System.IO.StreamWriter s = new System.IO.StreamWriter(fs))
				s.WriteLine(Math.Round(high, 3).ToString() +"");
		}
		else //if the file exists
		{
			string text = System.IO.File.ReadAllText(@filePath);
			print (text);
			high = float.Parse(text); //stores the read highscore in the variable high
		}

		if (high < survival_controller.score) //if the new score is higher than the previous highscore
		{
			prevHighScore.text = "High Score: " + (Math.Round(survival_controller.score, 3)).ToString() + "s";
			//write the highscore to the file
			System.IO.File.WriteAllText(@filePath, (Math.Round(survival_controller.score, 3)).ToString() +"");
		}
		else
		{
			prevHighScore.text = "High Score: " + Math.Round(high, 3) + "s";
		}
		score.text = (Math.Round(survival_controller.score, 3)).ToString() + "s";
	}
}
