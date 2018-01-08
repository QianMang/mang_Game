using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockActivity : MonoBehaviour {
	GameObject camera;
	public float rotateSpeed=0.05f;
	string level;
	Vector3 rotate;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
		level = GameObject.FindGameObjectWithTag ("level").name;
		rotate=new Vector3 (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.transform.position.z > this.transform.position.z) {

			GameObject.Find ("Main Camera").GetComponent<CreateBlock> ().destroyBlock ();
			Destroy(this.gameObject);

		}
		if (level == "Level1") {
			
			this.transform.Rotate (rotate*rotateSpeed);

		}

	}


}
