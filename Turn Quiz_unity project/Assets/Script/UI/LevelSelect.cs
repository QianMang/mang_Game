using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour {
	public TweenAlpha LevelSelectPanel;
	string levelName;
	// Use this for initialization
	void Start () {
		levelName = GetComponent<Transform> ().name.Trim();
	}
	



	public void OnLevelClick()
	{
		
		string enable_click = GetComponent<ShowLevel> ().detail_split [0];
		if (enable_click != "0" || levelName.Trim () == "level1" ) {  ////
			Invoke ("LoadScenes", 1.3f);
			LevelSelectPanel.PlayForward ();
		}
	}
	void LoadScenes()
	{
		levelName = GetComponent<Transform> ().name.Trim();
		print (levelName);
		Application.LoadLevel ("GameUI");
		Application.LoadLevelAdditive (levelName);
	}
}
