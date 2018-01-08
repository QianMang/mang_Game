using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidActivity : MonoBehaviour {
	GameObject camera;
	float upSpeed;
	float rotateSpeed;
	public float forwardSpeed=0.25f;
	// Use this for initialization
	void Start () {
		camera= GameObject.Find ("Main Camera");
		upSpeed = Random.Range (0.2f, 0.5f);
		rotateSpeed = Random.Range (2f, 3f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (camera.transform.position.z > this.transform.position.z || this.transform.position.y>=45) {

			GameObject.Find ("Main Camera").GetComponent<CreateScene> ().destroyCube ();
			Destroy(this.gameObject);

		}
		this.transform.Translate (0,upSpeed,forwardSpeed,Space.World);
		this.transform.Rotate (Vector3.up * rotateSpeed);
	}
}
