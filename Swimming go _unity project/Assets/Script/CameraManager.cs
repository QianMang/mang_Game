using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	float cameraSpeed;

	// Use this for initialization
	void Start () {
        cameraSpeed = GameObject.Find("Main Camera").GetComponent<GameManager>().GetCreateLimit_unit() / (float)GameObject.Find("Main Camera").GetComponent<GameManager>().GetCreateTime();
        //Debug.Log(cameraSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate (Vector3.right * cameraSpeed*Time.deltaTime);
	}
}
