using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_playInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("playInfo", 4.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void playInfo()
	{
		GetComponent<MovePlayer>().setAllDirectionBool ();
		GameObject.Find ("arrow").GetComponent<TweenAlpha> ().PlayForward ();
		GameObject.Find ("arrow").GetComponent<TweenPosition> ().PlayForward ();
		Invoke("enableMove",3f);

	}
	public void enableMove()
	{
		GetComponent<MovePlayer> ().setAllDirectionBool ();
		Destroy (GameObject.Find ("arrow"));
	}
}
