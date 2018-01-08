using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallActivity : MonoBehaviour {
	GameObject camera;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.transform.position.z > this.transform.position.z) {

			GameObject.Find ("Main Camera").GetComponent<CreateEnergyBall> ().destroyEnergyBall ();
			Destroy(this.gameObject);

		}
	}

//	void OnTriggerEnter(Collider entity){
//		if (entity.tag == "block") {
//			GameObject.Find ("Main Camera").GetComponent<CreateEnergyBall> ().destroyEnergyBall ();
//			print ("dddddd");
//			Destroy(this.gameObject);
//		}
//
//	}
}
