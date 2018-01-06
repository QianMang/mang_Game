using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_over : MonoBehaviour {
	GameObject finish_panel;
	// Use this for initialization
	void Start () {
		finish_panel = GameObject.FindWithTag ("FinishPanel");
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("player").transform.position == transform.position 
			&& GameObject.Find ("player").GetComponent<MovePlayer> ().IsStart==true) {
			print ("Game finished");
			finish_panel.GetComponent<TweenPosition> ().PlayForward ();
			GameObject.Find ("player").GetComponent<MovePlayer> ().IsStart = false;
			//Destroy (GameObject.Find ("player"));
		}
	}
}
