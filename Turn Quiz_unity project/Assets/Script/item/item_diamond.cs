using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_diamond : MonoBehaviour {
	public Sprite diamond_big;
	bool flag=true;
	int num;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("player").transform.position == transform.position && flag==true) {
			flag = false;
			GetComponent<UIPlaySound> ().enabled = true;
			GetComponent<SpriteRenderer> ().sprite = diamond_big;
			GetComponent<TweenAlpha> ().PlayForward ();
			GetComponent<TweenPosition> ().PlayForward ();
			GetComponent<TweenScale> ().PlayForward ();

			GameObject.Find ("Main Camera").GetComponent<LevelInfo> ().diamond_num++;
			GamePanelDiamond ();

			Invoke ("destroyThis", 2.5f);
		}
	}

	void destroyThis()
	{
		Destroy(this.gameObject);

	}

	void GamePanelDiamond()
	{
		num = GameObject.Find ("Main Camera").GetComponent<LevelInfo> ().diamond_num;
		if (num == 1) {
			Invoke ("PlayDiamondTween1",2);

		} else if (num == 2) {
			Invoke ("PlayDiamondTween2",2);

		} else if (num == 3) {
			Invoke ("PlayDiamondTween3",2);


		}
	}

	void PlayDiamondTween1()
	{
		GameObject.Find ("diamond_1_0").GetComponent<TweenScale> ().PlayForward ();
	}
	void PlayDiamondTween2()
	{
		GameObject.Find ("diamond_2_0").GetComponent<TweenScale> ().PlayForward ();
	}
	void PlayDiamondTween3()
	{
		GameObject.Find ("diamond_3_0").GetComponent<TweenScale> ().PlayForward ();
	}

}
