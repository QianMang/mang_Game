using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_wall_turn : MonoBehaviour {
	float rotate;
	// Use this for initialization
	void Start () {
		rotate = this.transform.eulerAngles.z;
	}
	
	public void arrow_wall_turn()
	{
		if (GameObject.Find ("player").transform.position != transform.position) {
			if (rotate == 0) {
				this.transform.eulerAngles = new Vector3 (0, 0, 180);
				rotate = 180;
				this.GetComponent<Arrow_wall> ().setDirectionNum (-2);
			} else if (rotate == 180) {
				this.transform.eulerAngles = new Vector3 (0, 0, 0);
				rotate = 0;
				this.GetComponent<Arrow_wall> ().setDirectionNum (2);
			} else if (rotate == 90) {
				this.transform.eulerAngles = new Vector3 (0, 0, 270);
				rotate = 270;
				this.GetComponent<Arrow_wall> ().setDirectionNum (1);
			} else if (rotate == 270) {
				this.transform.eulerAngles = new Vector3 (0, 0, 90);
				rotate = 90;
				this.GetComponent<Arrow_wall> ().setDirectionNum (-1);
			}


		}

	}
}
