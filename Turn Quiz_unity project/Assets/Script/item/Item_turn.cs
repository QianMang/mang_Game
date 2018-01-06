using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_turn : MonoBehaviour {
	bool flag=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("player").transform.position == transform.position && flag==false) {
			flag = true;
			GetComponent<UIPlaySound> ().enabled = true;
			GetComponent<TweenScale> ().PlayForward ();
			GetComponent<TweenAlpha> ().PlayForward ();

			GameObject[] zeroOne_WallList = GameObject.FindGameObjectsWithTag ("01wall");
			for (int i = 0; i < zeroOne_WallList.Length; i++) {
				zeroOne_WallList [i].GetComponent<Wall_turn_zeroOrOne> ().wall_zeroOrOne_turn ();
			}
			GameObject[] arrow_WallList = GameObject.FindGameObjectsWithTag ("01arrowWall");
			for (int i = 0; i < arrow_WallList.Length; i++) {
				arrow_WallList [i].GetComponent<Arrow_wall_turn> ().arrow_wall_turn ();

			}
			Invoke ("destroy_this", 1.4f);

		}
	}
	void destroy_this()
	{
		Destroy (this.gameObject);
	}
}
