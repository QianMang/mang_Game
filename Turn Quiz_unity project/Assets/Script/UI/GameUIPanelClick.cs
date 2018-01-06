using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIPanelClick : MonoBehaviour {
	bool clickIsabled = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void enableClick()
	{
		clickIsabled=true;

	}

	public void OnRetryClick()
	{
		if (clickIsabled == false)
			return;
		print ("retry click");	
		GameObject currentlevel=GameObject.FindGameObjectWithTag ("level");
		string currentlevel_name = currentlevel.name.Trim();
		Application.LoadLevel ("GameUI");
		Application.LoadLevelAdditive (currentlevel_name);
	}
	public void OnMenuClick()
	{
		if (clickIsabled == false)
			return;
		print ("menu click");
		GameObject.Find ("Alpha_control").GetComponent<TweenAlpha> ().PlayReverse ();
		Invoke ("LoadMenu", 1.5f);


	}
	void LoadMenu()
	{
		Application.LoadLevel ("MenuUI");
	}
}
