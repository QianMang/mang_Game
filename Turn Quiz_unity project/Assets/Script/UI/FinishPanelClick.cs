using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPanelClick : MonoBehaviour {
	bool clickIsabled=false;
	bool finishFlag=false;
	int diamondNum;
	int requireDiamond;
	int TotalDiamondNum;
	string lastLevel_name;
	string newlastLevel_name;
	// Use this for initialization
	void Start () {
		print ("finishpanelClick");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void diamond_collect()   //after finishPanel_tween, once
	{
		if(finishFlag==false)
			Invoke ("PlayDiamondTween", 0.5f);

		finishFlag = true;
	}

	void PlayDiamondTween()  //tween and result_save
	{
		GameObject.Find ("GameUIPanel").GetComponent<TweenPosition> ().PlayForward ();
		GameObject.Find ("Alpha_control").GetComponent<TweenAlpha> ().PlayReverse ();
		diamondNum=GameObject.Find ("Main Camera").GetComponent<LevelInfo> ().diamond_num;
		if (diamondNum == 1) {
			GameObject.Find ("diamond_finish_1_0").GetComponent<TweenScale> ().PlayForward ();
			SaveProcess (1,1,0,0);
			Invoke ("enableclick", 1);
		} else if (diamondNum == 2) {
			GameObject.Find ("diamond_finish_1_0").GetComponent<TweenScale> ().PlayForward ();
			GameObject.Find ("diamond_finish_2_0").GetComponent<TweenScale> ().PlayForward ();
			SaveProcess (1,1,1,0);
			Invoke ("enableclick", 2);
		} else if (diamondNum == 3) {
			GameObject.Find ("diamond_finish_1_0").GetComponent<TweenScale> ().PlayForward ();
			GameObject.Find ("diamond_finish_2_0").GetComponent<TweenScale> ().PlayForward ();
			GameObject.Find ("diamond_finish_3_0").GetComponent<TweenScale> ().PlayForward ();
			GameObject.Find ("perfectLabel").GetComponent<TweenScale> ().PlayForward ();
			SaveProcess (1,1,1,1);
			Invoke ("enableclick", 3f);
		} else {
			SaveProcess (1,0,0,0);
			Invoke ("enableclick", 0.5f);
		}
	}
	void enableclick()
	{
		clickIsabled = true;

	}
	void SaveProcess(int unlock,int diamond1,int diamond2,int diamond3)
	{
		
		TotalDiamondNum = GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().getTotalDiamond ();

		
		string d1 = diamond1.ToString ();
		string d2 = diamond2.ToString ();
		string d3 = diamond3.ToString ();
		print (d1 + d2 + d3);
		GameObject currentlevel=GameObject.FindGameObjectWithTag ("level");
		string currentlevel_name = currentlevel.name.Trim();
		string nextlevel_name = nextLevel (currentlevel_name);
		string preSavedString=GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().getLevel (currentlevel_name);
		//GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().saveLastLevel (nextlevel_name);   
		print ("pre:" + preSavedString);
		if (preSavedString != null) {    // not first time complete
			string[] pre_split = preSavedString.Split (',');
			int lastDiamondNum=0;
			if (pre_split [1] == "1")
				lastDiamondNum++;
			if (pre_split [2] == "1")
				lastDiamondNum++;
			if (pre_split [3] == "1")
				lastDiamondNum++;
			d1 = pre_split [1] == "1" ? pre_split [1] : d1;
			d2 = pre_split [2] == "1" ? pre_split [2] : d2;
			d3 = pre_split [3] == "1" ? pre_split [3] : d3;
			if(diamondNum>lastDiamondNum)
				TotalDiamondNum = TotalDiamondNum + diamondNum - lastDiamondNum;
				
		} else {            //first time complete
			TotalDiamondNum = TotalDiamondNum + diamondNum;
		}
		string SaveString;
		SaveString = unlock.ToString () + "," + d1 + "," + d2 + "," + d3;
		print ("save:"+d1 + d2 + d3);
		string lockString = GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().getLastLevel ();


		UnlockLevel(lockString);
	
		GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().saveLevel (SaveString, currentlevel_name);
		GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().saveTotalDiamond (TotalDiamondNum);
	}

	 void UnlockLevel(string lockString)
	{
		string[] lockInfo=lockString.Split(',');
		lastLevel_name = lockInfo [0];
		string num = lockInfo [1];
		int num2 = int.Parse (num);
		if (TotalDiamondNum >= num2) {
			newlastLevel_name = nextLevel (lastLevel_name);
			string lastLevelSaveString = "1,0,0,0";
			GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().saveLastLevel (newlastLevel_name,requireDiamond.ToString());
			Debug.Log ("unlock");
			GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().saveLevel (lastLevelSaveString, lastLevel_name);
			string nextLockString=GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().getLastLevel ();

			UnlockLevel (nextLockString); //检查第二个

		}
			

	}


	public void OnNextBtnClick()
	{
		
		if (clickIsabled == false)
			return;
		if (checkNextLevel () == false ) {
			if (GameObject.Find ("FinishPanel/moreDiamond") == null)
				return;
			GameObject.Find ("FinishPanel/moreDiamond").GetComponent<TweenScale> ().PlayForward ();
			Invoke ("closeBubble", 3.5f);
			return;
		}
			
		print ("next level click");
		GameObject.Find ("FinishPanel").GetComponent<TweenPosition> ().PlayReverse ();
		Invoke ("LoadNextLevel", 1.5f);

	}

	bool checkNextLevel()
	{
		string levelName;
		GameObject currentlevel=GameObject.FindGameObjectWithTag ("level");
		string currentlevel_name = currentlevel.name.Trim();
		levelName = nextLevel (currentlevel_name);
		if (levelName == "No") {  //final level
			Destroy(GameObject.Find("FinishPanel/moreDiamond"));
			OnMenuBtnClick ();
			return false;
		}
		else{
			string levelstring=GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().getLevel (levelName);
			if (levelstring == null)
				return false;
			return true;
		}
	}

	void closeBubble()
	{
		GameObject.Find ("FinishPanel/moreDiamond").GetComponent<TweenScale> ().PlayReverse ();

	}
	void AllLevelClear()
	{
		Application.LoadLevel ("MenuUI");

	}
	public void OnRetryBtnClick()
	{
		if (clickIsabled == false)
			return;
		print ("retry click");	
		GameObject currentlevel=GameObject.FindGameObjectWithTag ("level");
		string currentlevel_name = currentlevel.name.Trim();
		Application.LoadLevel ("GameUI");
		Application.LoadLevelAdditive (currentlevel_name);
	}

	public void OnMenuBtnClick()
	{
		if (clickIsabled == false)
			return;
		print ("menu click");
		GameObject.Find ("FinishPanel").GetComponent<TweenPosition> ().PlayReverse ();
		Invoke ("LoadMenu", 1.5f);
	}

	void LoadNextLevel()
	{
		string levelName;
		GameObject currentlevel=GameObject.FindGameObjectWithTag ("level");
		string currentlevel_name = currentlevel.name.Trim();
		levelName = nextLevel (currentlevel_name);
		print (levelName);
		Application.LoadLevel ("GameUI");
		Application.LoadLevelAdditive (levelName);

	}
	void LoadMenu()
	{
		Application.LoadLevel ("MenuUI");
	}


	string nextLevel (string currentLevel){
		switch (currentLevel) {
		case "level1":
			requireDiamond = 1;
			return "level2";
			break;
		case "level2":
			requireDiamond = 3;
			return "level3";
			break;
		case "level3":
			requireDiamond = 6;
			return "level4";
			break;
		case "level4":
			requireDiamond = 9;
			return "level5";      
			break;
		case "level5":
			requireDiamond = 11;
			return "level6";
			break;
		case "level6":
			requireDiamond = 13;
			return "level7";
			break;
		case "level7":
			requireDiamond = 15;
			return "level8";
			break;
		case "level8":
			requireDiamond = 17;
			return "level9";
			break;
		case "level9":
			requireDiamond = 19;
			return "level10";
			break;
		case "level10":
			requireDiamond = 20;
			return "level11";
			break;
		case "level11":
			requireDiamond = 22;
			return "level12";
			break;
		case "level12":
			requireDiamond = 24;
			return "level13";
			break;
		case "level13":
			requireDiamond = 26;
			return "level14";
			break;
		case "level14":
			requireDiamond = 29;
			return "level15";
			break;
		case "level15":
			requireDiamond = 32;
			return "level16";
			break;
		default:
			requireDiamond = 10000;
			return "No";

		}

	}

}
