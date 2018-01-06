using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour {
	[HideInInspector]
	public int diamond_num = 0;
	int step;
	GameObject label;
	public int[,] Level; 
	// Use this for initialization
	void Start () {
		step = 0;
		set_LevelMatraix_and_info ();
	}
	


	void set_LevelMatraix_and_info()
	{
		label = GameObject.Find ("level_name_label");
		GameObject currentlevel=GameObject.FindGameObjectWithTag ("level");
		string currentlevel_name = currentlevel.name.Trim();
		level_match (currentlevel_name);

	}
	void level_match(string name)
	{
		switch (name) 
		{
		case "level1":
			print ("level1");
			Level = GetComponent<Level> ().level1; 
			label.GetComponent<UILabel> ().text = "1.First Step";   break;
		case "level2":
			print ("level2");
			Level = GetComponent<Level> ().level2;
			label.GetComponent<UILabel> ().text = "2.Child"; break;
		case "level3":
			print ("level3");
			Level = GetComponent<Level> ().level3;
			label.GetComponent<UILabel> ().text = "3.Sandclock"; break;

		case "level4":
			print ("level4");
			Level = GetComponent<Level> ().level4;
			label.GetComponent<UILabel> ().text = "4.Bacteria"; break;
		case "level5":
			print ("level5");
			Level = GetComponent<Level> ().level5;
			label.GetComponent<UILabel> ().text = "5.Flower"; break;
		case "level6":
			print ("level6");
			Level = GetComponent<Level> ().level6;
			label.GetComponent<UILabel> ().text = "6.Treasure Room"; break;

		case "level7":
			print ("level7");
			Level = GetComponent<Level> ().level7;
			label.GetComponent<UILabel> ().text = "7.Factory"; break;

		case "level8":
			print ("level8");
			Level = GetComponent<Level> ().level8;
			label.GetComponent<UILabel> ().text = "8.FactoryII"; break;
		case "level9":
			print ("level9");
			Level = GetComponent<Level> ().level9;
			label.GetComponent<UILabel> ().text = "9.Spiral"; break;

		case "level10":
			print ("level10");
			Level = GetComponent<Level> ().level10;
			label.GetComponent<UILabel> ().text = "10.Not big deal"; break;
		case "level11":
			Debug.Log ("level11");
			Level = GetComponent<Level> ().level11;
			label.GetComponent<UILabel> ().text = "11.Mirror"; break;
		case "level12":
			Debug.Log ("level12");
			Level = GetComponent<Level> ().level12;
			label.GetComponent<UILabel> ().text = "12.Wormhole"; break;
		case "level13":
			Debug.Log ("level13");
			Level = GetComponent<Level> ().level13;
			label.GetComponent<UILabel> ().text = "13.Cross the Universe"; break;
		case "level14":
			Debug.Log ("level14");
			Level = GetComponent<Level> ().level14;
			label.GetComponent<UILabel> ().text = "14.Infinity road"; break;
		case "level15":
			Debug.Log ("level15");
			Level = GetComponent<Level> ().level15;
			label.GetComponent<UILabel> ().text = "15.Maze"; break;
		case "level16":
			Debug.Log ("level16");
			Level = GetComponent<Level> ().level16;
			label.GetComponent<UILabel> ().text = "16.Champion"; break;
		}


	}
	public void setStep()
	{
		step++;
	}
	public int getStep()
	{

		return step;

	}

}
