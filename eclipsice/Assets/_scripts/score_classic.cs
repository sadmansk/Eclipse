using UnityEngine;
using System;
//using System.IO;

public class score_classic : MonoBehaviour
{

	public GUIText prevHighScore, score;
	public int high;
	private String filePath = Application.persistentDataPath + "/classic_highscore.txt";
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
			high = 0;
			using (System.IO.StreamWriter s = new System.IO.StreamWriter(fs))
				s.WriteLine(high +"");
			print("swag");
		}
		else //if the file exists
		{
			string text = System.IO.File.ReadAllText(@filePath);
			print (text);
			high = Convert.ToInt32(text); //stores the read highscore in the variable high
		}

		if (high < classic_controller.count) //if the new score is higher than the previous highscore
		{
			prevHighScore.text = "High Score: " + classic_controller.count;
			//TextAsset file = Resources.Load("classic_highscore.txt") as TextAsset;
			//			StreamWriter writer = new StreamWriter("Assets/classic_highscore.txt");
			//			writer.WriteLine(classic_controller.count + "");
			//write the highscore to the file
			System.IO.File.WriteAllText(@filePath, classic_controller.count +"");
		}
		else
		{
			prevHighScore.text = "High Score: " + high;
		}
		score.text = classic_controller.count + "";

	}
}
