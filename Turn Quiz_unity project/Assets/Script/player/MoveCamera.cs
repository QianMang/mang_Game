using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
	Vector3 PlayerPosition;



	void Start () {
		

	}
	

	public void MoveCamera_check () {
		PlayerPosition = GameObject.Find ("player").GetComponent<Transform> ().position;
		playCameraTween ();
		//Invoke ("check_and_change_Tween", 1);
		//check_and_change_Tween ();


	}
	void playCameraTween()
	{
		
		if (this.transform.position.x == 0 && this.transform.position.y == 0) {
			if (PlayerPosition.x == 6) {
				GetComponent<TweenPosition> ().PlayForward ();
				Invoke ("check_and_change_Tween", 0.1f);
				//rightArrow.transform.eulerAngles = new Vector3 (0, 0, 90);
			} else if (PlayerPosition.y == -10) {
				GetComponent<TweenPosition> ().PlayForward ();
				Invoke ("check_and_change_Tween", 0.1f);
				//leftArrow.transform.eulerAngles = new Vector3 (0, 0, 270);
			} else {
				check_and_change_Tween ();
			}
		} else if (this.transform.position.x == 11 && this.transform.position.y == 0) {
			if (PlayerPosition.x == 5) {
				GetComponent<TweenPosition> ().PlayForward ();
				Invoke ("check_and_change_Tween", 0.1f);
				//leftArrow.transform.eulerAngles = new Vector3 (0, 0, 90);
			}
			else if (PlayerPosition.y == -10) {
				GetComponent<TweenPosition> ().PlayForward ();
				Invoke ("check_and_change_Tween", 0.1f);
				//rightArrow.transform.eulerAngles = new Vector3 (0, 0, 270);
			}else {
				check_and_change_Tween ();
			}
		} else if (this.transform.position.x == 11 && this.transform.position.y == -17) {
			if (PlayerPosition.x == 5) {
				GetComponent<TweenPosition> ().PlayForward ();
				Invoke ("check_and_change_Tween", 0.1f);
				//leftArrow.transform.eulerAngles = new Vector3 (0, 0, 270);
			}
			else if (PlayerPosition.y == -9) {
				GetComponent<TweenPosition> ().PlayForward ();
				Invoke ("check_and_change_Tween", 0.1f);
				//rightArrow.transform.eulerAngles = new Vector3 (0, 0, 90);
			}else {
				check_and_change_Tween ();
			}
		} else if (this.transform.position.x == 0 && this.transform.position.y == -17) {
			if (PlayerPosition.x == 6) {
				GetComponent<TweenPosition> ().PlayForward ();
				Invoke ("check_and_change_Tween", 0.1f);
				//rightArrow.transform.eulerAngles = new Vector3 (0, 0, 270);
			}
			else if (PlayerPosition.y == -9) {
				GetComponent<TweenPosition> ().PlayForward ();
				Invoke ("check_and_change_Tween", 0.1f);
				//leftArrow.transform.eulerAngles = new Vector3 (0, 0, 90);
			}
			else {
				check_and_change_Tween ();
			}
		}

	}
	void check_and_change_Tween()
	{
		
		if (PlayerPosition.x == 5 && PlayerPosition.y >= -9) {
			this.GetComponent<TweenPosition> ().from = new Vector3 (0, 0, -10);
			this.GetComponent<TweenPosition> ().to = new Vector3 (11, 0, -10);
		} else if (PlayerPosition.x == 6 && PlayerPosition.y >= -9) {
			this.GetComponent<TweenPosition> ().from = new Vector3 (11, 0, -10);
			this.GetComponent<TweenPosition> ().to = new Vector3 (0, 0, -10);
		}else if (PlayerPosition.x == 5 && PlayerPosition.y < -9) {
			this.GetComponent<TweenPosition> ().from = new Vector3 (0, -17, 10);
			this.GetComponent<TweenPosition> ().to = new Vector3 (11, -17, -10);
		}else if (PlayerPosition.x == 6 && PlayerPosition.y < -9) {
			this.GetComponent<TweenPosition> ().from = new Vector3 (11, -17, -10);
			this.GetComponent<TweenPosition> ().to = new Vector3 (0, -17, -10);
		}else if (PlayerPosition.y == -9 && PlayerPosition.x <= 5) {
			this.GetComponent<TweenPosition> ().from = new Vector3 (0, 0, -10);
			this.GetComponent<TweenPosition> ().to = new Vector3 (0, -17, -10);
		}else if (PlayerPosition.y == -10 && PlayerPosition.x <= 5) {
			this.GetComponent<TweenPosition> ().from = new Vector3 (0, -17, -10);
			this.GetComponent<TweenPosition> ().to = new Vector3 (0, 0, -10);
		}else if (PlayerPosition.y == -9 && PlayerPosition.x > 5) {
			this.GetComponent<TweenPosition> ().from = new Vector3 (11, 0, -10);
			this.GetComponent<TweenPosition> ().to = new Vector3 (11, -17, -10);
		}else if (PlayerPosition.y == -10 && PlayerPosition.x > 5) {
			this.GetComponent<TweenPosition> ().from = new Vector3 (11, -17, -10);
			this.GetComponent<TweenPosition> ().to = new Vector3 (11, 0, -10);
		}


	}
}
