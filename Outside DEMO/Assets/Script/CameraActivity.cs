using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraActivity : MonoBehaviour {
	public float cameraSpeed_forward = 0.5f;
	public float cameraSpeed_xyAxis=0.5f;
	public float cameraSpeed_rotate=1f;
	public float camera_xyAxisLimit=1f;
	//int xyPosition=0;//1,2,3,4代表象限
	Vector3 rotateVec_left;
	Vector3 rotateVec_right;
//	float z;
//	float lastZ;
	// Use this for initialization
	void Start () {
		rotateVec_left = new Vector3 (0, 0, cameraSpeed_rotate);
		rotateVec_right = new Vector3 (0, 0, -cameraSpeed_rotate);
//		z=this.transform.position.z;//
//		lastZ=this.transform.position.z;//
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		controlCameraMove ();
	}

	void controlCameraMove(){
//		lastZ = z;
        if (Input.GetKey(KeyCode.W)) {
			if (this.transform.position.y < camera_xyAxisLimit) {
				this.gameObject.transform.Translate (0, cameraSpeed_xyAxis, 0);
			}
		}
		else if (Input.GetKey (KeyCode.S)) {
			if (this.transform.position.y > -camera_xyAxisLimit) {
				this.gameObject.transform.Translate (0, -cameraSpeed_xyAxis,0 );
			}
		} 
		else if (Input.GetKey (KeyCode.A)) {
			if (this.transform.position.x > -camera_xyAxisLimit) {
				this.gameObject.transform.Translate (-cameraSpeed_xyAxis, 0, 0);

				//this.gameObject.transform.Rotate (rotateVec_left);
			}
		}
		else if (Input.GetKey (KeyCode.D)) {
			if (this.transform.position.x < camera_xyAxisLimit) {
				this.gameObject.transform.Translate (cameraSpeed_xyAxis, 0, 0);
//					if(this.gameObject.transform.localRotation.z>-10)
//						this.gameObject.transform.Rotate (rotateVec_right);
			}
		} 
		
		this.gameObject.transform.Translate (0, 0, cameraSpeed_forward,Space.World);
//		z=this.transform.position.z;
//		print (z - lastZ);
	}

	void cameraFieldEffect(){



	}

	void OnTriggerEnter(Collider entity){
		if (entity.tag == "block") {
            this.GetComponent<ScoreAndHealth>().ChangeLife(20);
			this.GetComponent<ShakeCamera> ().shake ();
			GameObject.Find ("Main Camera").GetComponent<CreateBlock> ().destroyBlock ();
		} else if (entity.tag == "energyBall") {
            this.GetComponent<ScoreAndHealth>().ChangeLife(-20);
			GameObject.Find ("Main Camera").GetComponent<CreateEnergyBall> ().destroyEnergyBall ();
		} else if (entity.tag == "laser") {
            this.GetComponent<ScoreAndHealth>().ChangeLife(10);
			this.GetComponent<ShakeCamera> ().shake ();
        }else if(entity.tag=="sun"){
            switch(GameObject.Find("UI Root").GetComponent<UIManager>().ClickLevelBtn){
                case 1:SceneManager.LoadScene("Level1");break;
                case 2:SceneManager.LoadScene("Level2"); break;
            }
        }
        if (entity.tag != "enemy") {
			Destroy (entity.gameObject);
		}
	}
}
