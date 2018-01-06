using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Show_Step : MonoBehaviour {
	int step;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		step=GameObject.Find ("Main Camera").GetComponent<LevelInfo> ().getStep();
		this.GetComponent<Text> ().text = "Step: " + step.ToString ();
	}
}
