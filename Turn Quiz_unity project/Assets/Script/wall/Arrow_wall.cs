using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_wall : MonoBehaviour {
	bool flag=false;
	int directionNum;
	int lastDirectionNum;
	// Use this for initialization
	void Start () {
		if (transform.eulerAngles.z ==0) {
			directionNum = 2;
		} else if (transform.eulerAngles.z ==90) {
			directionNum = -1;
		}else if (transform.eulerAngles.z ==270) {
			directionNum =1;
		}else if (transform.eulerAngles.z ==180) {
			directionNum = -2;
		}
		Debug.Log (directionNum);
	}
	public void setDirectionNum(int dNum)
	{
		directionNum = dNum;

	}
	// Update is called once per frame
	void Update () {
		if (transform.position == GameObject.Find ("player").transform.position)
			GameObject.Find ("player").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.72f);
		if (transform.position == GameObject.Find ("player").transform.position && flag == false) {
			GameObject.Find ("player").GetComponent<MovePlayer> ().setDirectionBool (directionNum);
			//GameObject.Find ("player").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.72f);
			flag = true;
			lastDirectionNum = directionNum;
		} else if (transform.position != GameObject.Find ("player").transform.position && flag == true) {
			GameObject.Find ("player").GetComponent<MovePlayer> ().setDirectionBool (lastDirectionNum);
			GameObject.Find ("player").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1f);
			flag = false;
		}

	}
}
