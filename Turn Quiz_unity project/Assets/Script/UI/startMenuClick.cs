using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenuClick : MonoBehaviour {
	public TweenPosition startPanel;
	public TweenPosition levelPanel;

	public void OnStartBtnClick()
	{
		print ("click");
		startPanel.PlayForward ();
		levelPanel.PlayForward ();
	}

	public void OnBackBtnClick()
	{
		print ("back");
		startPanel.PlayReverse ();
		levelPanel.PlayReverse ();

	}

}
