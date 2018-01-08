using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActivity : MonoBehaviour {
	
	Vector3 centerPosition;
	Vector3 zAxis;
	GameObject camera;
	float rotateSpeed=1;
	// Use this for initialization
	void Start () {
		
		zAxis = new Vector3 (0, 0, 1);
		float zPosition = this.transform.position.z;
		centerPosition = new Vector3 (0, 0, zPosition);
		camera = GameObject.Find ("Main Camera");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (camera.transform.position.z > this.transform.position.z) {
			
			GameObject.Find ("Main Camera").GetComponent<CreateScene> ().destroyCube ();
			Destroy(this.gameObject);

		}

		this.gameObject.transform.LookAt (centerPosition);
		this.gameObject.transform.RotateAround (centerPosition, zAxis, rotateSpeed * 0.02f);
	}

	public void setRotateSpeed(float speed){
		rotateSpeed = speed;
	}
}
