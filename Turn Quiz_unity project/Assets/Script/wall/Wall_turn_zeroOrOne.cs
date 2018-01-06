using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_turn_zeroOrOne : MonoBehaviour {

	public Sprite one;
	public Sprite zero;


	Vector2 v=new Vector2();

	// Use this for initialization
	void Start () {
		
		v.x = transform.position.x;
		v.y = transform.position.y;
	}

	public void wall_zeroOrOne_turn()
	{
		if (GameObject.Find ("player").transform.position != transform.position) {
			int k = GameObject.Find ("Main Camera").GetComponent<LevelInfo> ().Level [(int)(10f - v.y), (int)(6f + v.x)];
			if (k == 2) {
				k = 0;
				gameObject.GetComponent<SpriteRenderer> ().sprite = zero;
			} else if (k == 0) {
				k = 2;
				gameObject.GetComponent<SpriteRenderer> ().sprite = one;
			}
			GameObject.Find ("Main Camera").GetComponent<LevelInfo> ().Level [(int)(10f - v.y), (int)(6f + v.x)] = k;
		}
	}
		
}
