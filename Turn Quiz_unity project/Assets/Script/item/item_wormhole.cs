using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_wormhole : MonoBehaviour {
	public bool flag=false;
	GameObject anotherHole;

	// Use this for initialization
	void Start () {
		string tag = this.tag;
		switch (tag) {
		case "wormhole1":
			GameObject[] wormhole1 = GameObject.FindGameObjectsWithTag ("wormhole1");
			for (int i = 0; i <= 1; i++) {
				if (wormhole1 [i].transform.position != this.transform.position) {
					anotherHole = wormhole1 [i];
					break;
				}
			}
			break;
		case "wormhole2":
			GameObject[] wormhole2 = GameObject.FindGameObjectsWithTag ("wormhole2");
			for (int i = 0; i <= 1; i++) {
				if (wormhole2 [i].transform.position != this.transform.position) {
					anotherHole = wormhole2 [i];
					break;
				}
			}
			break;
		case "wormhole3":
			GameObject[] wormhole3 = GameObject.FindGameObjectsWithTag ("wormhole3");
			for (int i = 0; i <= 1; i++) {
				if (wormhole3 [i].transform.position != this.transform.position) {
					anotherHole = wormhole3 [i];
					break;
				}
			}
			break;
		case "wormhole4":
			GameObject[] wormhole4 = GameObject.FindGameObjectsWithTag ("wormhole4");
			for (int i = 0; i <= 1; i++) {
				if (wormhole4 [i].transform.position != this.transform.position) {
					anotherHole = wormhole4 [i];
					break;
				}
			}
			break;
		case "wormhole5":
			GameObject[] wormhole5 = GameObject.FindGameObjectsWithTag ("wormhole5");
			for (int i = 0; i <= 1; i++) {
				if (wormhole5 [i].transform.position != this.transform.position) {
					anotherHole = wormhole5 [i];
					break;
				}
			}
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("player").transform.position == transform.position && flag == false) {
			flag = true;
			GetComponent<UIPlaySound> ().enabled = true;
			GameObject player = GameObject.Find ("player");
			player.GetComponent<MovePlayer> ().setAllDirectionBool ();
			player.GetComponent<TweenAlpha> ().PlayForward ();
			Invoke ("changePlace", 0.5f);
			Invoke("closeSound",1);

		}
		if (GameObject.Find ("player").transform.position != transform.position) {
			flag = false;

		}
	}
	void changePlace()
	{
		anotherHole.GetComponent<item_wormhole> ().flag = true;
		GameObject.Find ("player").transform.position = anotherHole.transform.position;

		GameObject.Find ("player").GetComponent<TweenAlpha> ().PlayReverse ();
		Invoke ("moveIsable", 0.5f);


	}
	void closeSound()
	{
		GetComponent<UIPlaySound> ().enabled = false;
	}
	void moveIsable()
	{
		GameObject.Find ("player").GetComponent<MovePlayer> ().setAllDirectionBool ();

	}
}
