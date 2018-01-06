using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLevel : MonoBehaviour {
	string thisLevelName;
	string detail="0,0,0,0";
	public string[] detail_split;

	// Use this for initialization
	void Start () {
		thisLevelName = this.name.Trim();
		detail_split = detail.Split (',');

		detail = GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().getLevel (thisLevelName);

		print (detail);
		if (detail==null) {
			Show_level_firstTime ();
		}
		else if (detail != null) {
			Split_detail ();
			Show_level_diamond ();
		}
		Show_Total_Diamond_Num ();
	}

	public void Restart()
	{
		GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/lock").GetComponent<TweenScale> ().PlayReverse ();
		detail = "0,0,0,0";
		thisLevelName = this.name.Trim();
		detail_split = detail.Split (',');
		detail = GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().getLevel (thisLevelName);

		print (detail);
		if (detail==null) {
			Show_level_firstTime ();
		}
		else if (detail != null) {
			Split_detail ();
			Show_level_diamond ();
		}
		Show_Total_Diamond_Num ();
	}

	void Split_detail()
	{
		detail_split=detail.Split (',');
	}

	void Show_Total_Diamond_Num()
	{
		int num = GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().getTotalDiamond ();
		GameObject.Find ("UI Root/LevelSelectPanel/UpPanel/TotalDiamondLabel").GetComponent<UILabel> ().text = num.ToString ();

	}


	void Show_level_firstTime()
	{
		if (thisLevelName != "level1" ) {//////////
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/levelName/Label").GetComponent<UILabel> ().text = "? ? ?";
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_1").GetComponent<UISprite> ().color = new Color (0, 0, 0, 0f);
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_2").GetComponent<UISprite> ().color = new Color (0, 0, 0, 0f);
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_3").GetComponent<UISprite> ().color = new Color (0, 0, 0, 0f);
			//GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/lock").GetComponent<TweenScale> ().PlayReverse ();

			//GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName).GetComponent<UIButton> ().enabled = false;//
		} else {
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/lock").GetComponent<TweenScale> ().PlayForward ();
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_1").GetComponent<UISprite> ().color = new Color (1, 0.8431f, 0.1921f, 0.6235f);
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_2").GetComponent<UISprite> ().color = new Color (1, 0.8431f, 0.1921f, 0.6235f);
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_3").GetComponent<UISprite> ().color = new Color (1, 0.8431f, 0.1921f, 0.6235f);

		}

	}
	void Show_level_diamond()
	{
		Debug.Log(thisLevelName);
		if (detail_split [0] == "0") {
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/levelName/Label").GetComponent<UILabel> ().text = "? ? ?";
		} else {
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/lock").GetComponent<TweenScale> ().PlayForward ();
		
		}
		if (detail_split [1] == "1") {
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_1").GetComponent<UISprite> ().color = new Color (1, 0.4157f, 0, 0.8039f);
		} else {
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_1").GetComponent<UISprite> ().color = new Color (1, 0.8431f, 0.1921f, 0.6235f);
		}
		if (detail_split [2] == "1") {
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_2").GetComponent<UISprite> ().color = new Color (1, 0.4157f, 0, 0.8039f);
		} else {
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_2").GetComponent<UISprite> ().color = new Color (1, 0.8431f, 0.1921f, 0.6235f);
		}
		if (detail_split [3] == "1") {
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_3").GetComponent<UISprite> ().color = new Color (1, 0.4157f, 0, 0.8039f);
		}else {
			GameObject.Find ("UI Root/LevelSelectPanel/LevelSelectPanel_scroll/Grid/" + thisLevelName + "/diamond_3").GetComponent<UISprite> ().color = new Color (1, 0.8431f, 0.1921f, 0.6235f);
		}


	}
}
