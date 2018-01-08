using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivity : MonoBehaviour {
	public float Speed=0.1f;
	GameObject camera;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.transform.position.z > this.transform.position.z) {

			Destroy(this.gameObject);

		}
		transform.position += transform.forward * Time.deltaTime * Speed;
	}

	void OnTriggerEnter(Collider entity){
		if (entity.tag == "block") {
			Destroy (this.gameObject);

		}

	}
}
