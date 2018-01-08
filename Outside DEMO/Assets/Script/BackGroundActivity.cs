using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundActivity : MonoBehaviour {
	public float speed=0.25f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate (0, 0, speed, Space.World);
	}
}
