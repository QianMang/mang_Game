using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_playinfo : MonoBehaviour {
	Vector3 position;
	bool flag=true;
	bool flag2=true;
	// Use this for initialization
	void Start () {
		Invoke ("playInfo", 4.3f);
		position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position != position && flag==true) {
			Destroy (GameObject.Find("finger"));
			GetComponent<MovePlayer> ().setDirectionBool (2);
			flag = false;
		}
		if (this.transform.position.y == -3 && flag2==true) {

			flag2 = false;
			GameObject.Find ("arrow").GetComponent<TweenAlpha> ().PlayForward ();
			GameObject.Find ("arrow").GetComponent<TweenPosition> ().PlayForward ();
			GetComponent<MovePlayer> ().setAllDirectionBool ();
			Invoke ("enableMove2", 3);

		}
	}
	public void playInfo()
	{
		GetComponent<MovePlayer>().setAllDirectionBool ();
		GameObject.Find ("finger").GetComponent<TweenAlpha> ().PlayForward ();
		GameObject.Find ("finger").GetComponent<TweenPosition> ().PlayForward ();
		Invoke("enableMove",1.8f);

	}
	public void enableMove()
	{
		GetComponent<MovePlayer> ().setAllDirectionBool ();
		GetComponent<MovePlayer> ().setDirectionBool (2);

	}
	void enableMove2()
	{
		GetComponent<MovePlayer> ().setAllDirectionBool ();
		Destroy (GameObject.Find ("arrow"));
	}
}
