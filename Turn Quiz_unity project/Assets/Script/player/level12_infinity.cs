using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level12_infinity : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y == 8 && this.transform.position.x != -2 && this.transform.position.x!=-1) {
			this.transform.position = new Vector3 (this.transform.position.x, -9, 0);
		}
		if (this.transform.position.y == -10 && this.transform.position.x != -2 && this.transform.position.x != -1) {
			this.transform.position = new Vector3 (this.transform.position.x, 7, 0);

		}
	}
}
