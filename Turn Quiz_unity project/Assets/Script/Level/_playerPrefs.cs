using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _playerPrefs : MonoBehaviour {

	public string getLevel(string levelName)
	{
		print (levelName);
		levelName = levelName.Trim ();
		if(PlayerPrefs.HasKey (levelName)==false)
			return null;
		string levelDetail=PlayerPrefs.GetString (levelName);
		return levelDetail;
	}
	public void saveLevel(string levelResult,string levelName)
	{
		
		PlayerPrefs.SetString (levelName, levelResult);
		PlayerPrefs.Save ();
		print ("saved");
	}
	public void saveLastLevel (string levelName,string requireDiamond)
	{
		string Info = levelName + "," + requireDiamond;
		PlayerPrefs.SetString ("last", Info);
		PlayerPrefs.Save ();


	}
	public string getLastLevel()
	{
		
		if(PlayerPrefs.HasKey ("last")==false)
			return "level2,1";
		string levelmessage=PlayerPrefs.GetString ("last");
		return levelmessage;
	}
	public void saveTotalDiamond(int num)
	{
		PlayerPrefs.SetInt ("TotalDiamond", num);
		PlayerPrefs.Save();
		print("saved");
	}
	public int getTotalDiamond()
	{
		
		if(PlayerPrefs.HasKey ("TotalDiamond")==false)
			return 0;
		int num=PlayerPrefs.GetInt ("TotalDiamond");
		return num;
	}

	public void saveSound(int On_Off)
	{
		
		PlayerPrefs.SetInt ("Sound", On_Off);
		PlayerPrefs.Save ();
		print ("save sound");
	}
	public int getSound()
	{
		if(PlayerPrefs.HasKey ("Sound")==false)
			return 1;
		return PlayerPrefs.GetInt ("Sound");
	}


	public void clearData()
	{
		int sound = getSound ();   //remain sound
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
		saveSound (sound);
		GameObject[] leveltag = GameObject.FindGameObjectsWithTag ("levelSelectPanel_level");
		for (int i = 0; i < leveltag.Length; i++) {
			leveltag [i].GetComponent<ShowLevel> ().Restart ();
		}
	}

}
